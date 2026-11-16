using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FINAL_MINSUFINDER
{
    public static class UserDatabaseHelper
    {
        // ==========================================
        // CORE DATABASE RUNNERS (Internal)
        // ==========================================
        private static DataTable GetTable(string query)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private static bool RunQuery(string query, Action<SqlCommand> paramAction = null)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        paramAction?.Invoke(cmd);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ==========================================
        // 1. DASHBOARD METHODS
        // ==========================================
        public static DataRow GetDashboardCounts()
        {
            string query = @"
                SELECT
                    (SELECT COUNT(*) FROM FoundItems) AS FoundCount,
                    (SELECT COUNT(*) FROM LostItems WHERE Status = 'Lost') AS LostCount,
                    (SELECT COUNT(*) FROM Claims) AS ClaimCount,
                    (SELECT COUNT(*) FROM UsersAccount) AS UserCount";
            DataTable dt = GetTable(query);
            return (dt != null && dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }

        public static void LoadRecentActivities(DataGridView dgv)
        {
            string query = @"
                SELECT TOP 20 * FROM (
                    SELECT 'Registration' AS ActivityType, 'New student registered' AS Description, FullName AS ActivityUser, DateRegistered AS ActivityDate FROM UsersAccount
                    UNION ALL
                    SELECT 'Lost Item', CONCAT('Reported a lost item: ', ItemName), ItemOwner, DateLost FROM LostItems
                    UNION ALL
                    SELECT 'Found Item', CONCAT('Reported a found item: ', ItemName), Founder, DateFound FROM FoundItems
                    UNION ALL
                    SELECT 'Claim', CONCAT('Claimed an item: ', ItemName), ClaimantFullName, DateClaimed FROM Claims
                ) AS Activities
                ORDER BY ActivityDate DESC";
            dgv.DataSource = GetTable(query);
        }

        // ==========================================
        // 2. LOST ITEMS METHODS
        // ==========================================
        public static void LoadLostItems(DataGridView dgv)
        {
            string query = "SELECT LostItemID, ItemName, ItemDescription, DateLost, LastLocation, ItemOwner, Status FROM LostItems";
            dgv.DataSource = GetTable(query);
            if (dgv.Columns["LostItemID"] != null) dgv.Columns["LostItemID"].Visible = false;
        }

        public static bool AddLostItem(string name, string desc, DateTime dateLost, string location, string owner, string status)
        {
            string finalStatus = string.IsNullOrWhiteSpace(status) ? "Lost" : status.Trim();
            string query = @"INSERT INTO LostItems (ItemName, ItemDescription, DateLost, LastLocation, ItemOwner, Status) 
                             VALUES (@Name, @Desc, @Date, @Loc, @Owner, @Status)";
            return RunQuery(query, cmd => {
                cmd.Parameters.AddWithValue("@Name", name.Trim());
                cmd.Parameters.AddWithValue("@Desc", desc.Trim());
                cmd.Parameters.AddWithValue("@Date", dateLost);
                cmd.Parameters.AddWithValue("@Loc", location.Trim());
                cmd.Parameters.AddWithValue("@Owner", owner.Trim());
                cmd.Parameters.AddWithValue("@Status", finalStatus);
            });
        }

        public static bool UpdateLostItem(int id, string name, string desc, DateTime dateLost, string location, string owner, string status)
        {
            string query = @"UPDATE LostItems SET ItemName = @Name, ItemDescription = @Desc, DateLost = @Date, 
                             LastLocation = @Loc, ItemOwner = @Owner, Status = @Status WHERE LostItemID = @ID";
            return RunQuery(query, cmd => {
                cmd.Parameters.AddWithValue("@Name", name.Trim());
                cmd.Parameters.AddWithValue("@Desc", desc.Trim());
                cmd.Parameters.AddWithValue("@Date", dateLost);
                cmd.Parameters.AddWithValue("@Loc", location.Trim());
                cmd.Parameters.AddWithValue("@Owner", owner.Trim());
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@ID", id);
            });
        }

        public static bool DeleteLostItem(int id)
        {
            return RunQuery("DELETE FROM LostItems WHERE LostItemID = @ID", cmd => cmd.Parameters.AddWithValue("@ID", id));
        }

        // ==========================================
        // 3. FOUND ITEMS METHODS
        // ==========================================
        public static void LoadFoundItems(DataGridView dgv)
        {
            string query = "SELECT FoundItemID, ItemName, ItemDescription, DateFound, FoundLocation, Founder, Status FROM FoundItems";
            dgv.DataSource = GetTable(query);
            if (dgv.Columns["FoundItemID"] != null) dgv.Columns["FoundItemID"].Visible = false;
        }

        public static bool AddFoundItem(string name, string desc, DateTime dateFound, string location, string founder, string status = "Unclaimed", int lostItemId = -1)
        {
            string query = @"INSERT INTO FoundItems (ItemName, ItemDescription, DateFound, FoundLocation, Founder, Status)
                             VALUES (@Name, @Desc, @Date, @Loc, @Founder, @Status)";
            bool inserted = RunQuery(query, cmd => {
                cmd.Parameters.AddWithValue("@Name", name.Trim());
                cmd.Parameters.AddWithValue("@Desc", desc.Trim());
                cmd.Parameters.AddWithValue("@Date", dateFound);
                cmd.Parameters.AddWithValue("@Loc", location.Trim());
                cmd.Parameters.AddWithValue("@Founder", founder.Trim());
                cmd.Parameters.AddWithValue("@Status", status);
            });

            if (inserted && lostItemId != -1)
            {
                RunQuery("UPDATE LostItems SET Status = 'Found' WHERE LostItemID = @ID", cmd => cmd.Parameters.AddWithValue("@ID", lostItemId));
            }
            return inserted;
        }

        public static bool UpdateFoundItem(int id, string name, string desc, DateTime dateFound, string location, string founder, string status)
        {
            string query = @"UPDATE FoundItems SET ItemName = @Name, ItemDescription = @Desc, DateFound = @Date, 
                             FoundLocation = @Loc, Founder = @Founder, Status = @Status WHERE FoundItemID = @ID";
            return RunQuery(query, cmd => {
                cmd.Parameters.AddWithValue("@Name", name.Trim());
                cmd.Parameters.AddWithValue("@Desc", desc.Trim());
                cmd.Parameters.AddWithValue("@Date", dateFound);
                cmd.Parameters.AddWithValue("@Loc", location.Trim());
                cmd.Parameters.AddWithValue("@Founder", founder.Trim());
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@ID", id);
            });
        }

        public static bool DeleteFoundItem(int id)
        {
            return RunQuery("DELETE FROM FoundItems WHERE FoundItemID = @ID", cmd => cmd.Parameters.AddWithValue("@ID", id));
        }

        // ==========================================
        // 4. CLAIMS METHODS
        // ==========================================
        public static void LoadClaims(DataGridView dgv)
        {
            string query = @"SELECT ClaimID, OwnerFullName, ClaimantFullName, DateClaimed, ItemName, FinderFullName 
                             FROM Claims ORDER BY ClaimID DESC";
            dgv.DataSource = GetTable(query);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static bool SubmitClaim(string itemName, string ownerName, string finderName, string claimantName, DateTime dateClaimed, int foundItemID = -1)
        {
            string query = @"INSERT INTO Claims (ItemName, OwnerFullName, FinderFullName, ClaimantFullName, DateClaimed)
                     VALUES (@Item, @Owner, @Finder, @Claimant, @Date)";

            bool success = RunQuery(query, cmd => {
                cmd.Parameters.AddWithValue("@Item", itemName.Trim());
                cmd.Parameters.AddWithValue("@Owner", ownerName.Trim());
                cmd.Parameters.AddWithValue("@Finder", finderName.Trim());
                cmd.Parameters.AddWithValue("@Claimant", claimantName.Trim());
                cmd.Parameters.AddWithValue("@Date", dateClaimed);
            });

            // Kung successful ang pag-save ng claim at may valid na foundItemID, i-update ang status sa FoundItems
            if (success && foundItemID != -1)
            {
                RunQuery("UPDATE FoundItems SET Status = 'Claimed' WHERE FoundItemID = @ID", cmd => {
                    cmd.Parameters.AddWithValue("@ID", foundItemID);
                });
            }

            return success;
        }

        // ==========================================
        // 5. USERS ACCOUNT METHODS
        // ==========================================
        public static void LoadUsers(DataGridView dgv)
        {
            dgv.DataSource = GetTable("SELECT * FROM UsersAccount");
        }

        public static bool UpdateUser(string idNumber, string fullName, string userName, string course, string password)
        {
            string query = @"UPDATE UsersAccount SET FullName = @FullName, UserName = @UserName, 
                             Course = @Course, Password = @Password WHERE IdNumber = @IdNumber";
            return RunQuery(query, cmd => {
                cmd.Parameters.AddWithValue("@IdNumber", idNumber.Trim());
                cmd.Parameters.AddWithValue("@FullName", fullName.Trim());
                cmd.Parameters.AddWithValue("@UserName", userName.Trim());
                cmd.Parameters.AddWithValue("@Course", course.Trim());
                cmd.Parameters.AddWithValue("@Password", password.Trim());
            });
        }

        public static bool DeleteUser(string idNumber)
        {
            return RunQuery("DELETE FROM UsersAccount WHERE IdNumber = @IdNumber", cmd => cmd.Parameters.AddWithValue("@IdNumber", idNumber.Trim()));
        }

        // ==========================================
        // 6. LEADERBOARD METHOD
        // ==========================================
        public static DataTable GetLeaderboard(string filterType, out string timeLabelText)
        {
            string dateCondition = "";
            filterType = filterType?.Trim();

            if (filterType == "Today")
            {
                dateCondition = "WHERE CAST(DateFound AS DATE) = CAST(GETDATE() AS DATE)";
                timeLabelText = "of this Day";
            }
            else if (filterType == "This Week" || filterType == "this Week")
            {
                dateCondition = "WHERE DateFound >= DATEADD(day, -7, GETDATE())";
                timeLabelText = "of this Week";
            }
            else if (filterType == "This Month" || filterType == "this Month")
            {
                dateCondition = "WHERE MONTH(DateFound) = MONTH(GETDATE()) AND YEAR(DateFound) = YEAR(GETDATE())";
                timeLabelText = "of this Month";
            }
            else
            {
                dateCondition = "";
                timeLabelText = "of All Time";
            }

            string query = $@"SELECT ROW_NUMBER() OVER (ORDER BY COUNT(*) DESC) AS [Rank], 
                              LTRIM(RTRIM(Founder)) AS [Student Name], COUNT(*) AS [Items Reported],
                              (COUNT(*) * 10) AS [Total Points] 
                              FROM FoundItems {dateCondition}
                              GROUP BY LTRIM(RTRIM(Founder))
                              HAVING LTRIM(RTRIM(Founder)) IS NOT NULL AND LTRIM(RTRIM(Founder)) <> '' 
                              ORDER BY [Items Reported] DESC";

            return GetTable(query);
        }
    }
}   