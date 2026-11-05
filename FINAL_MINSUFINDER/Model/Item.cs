using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_MINSUFINDER.Model
{
    public class Item
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public DateTime DateFound { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public bool IsClaimed { get; set; }

        public Item(string name, string category, string location, DateTime dateFound, string imagePath, string description)
        {
            ItemId = Guid.NewGuid().ToString().Substring(0, 8); 
            ItemName = name;
            Category = category;
            Location = location;
            DateFound = dateFound;
            ImagePath = imagePath;
            Description = description;
            IsClaimed = false;
        }
    }
}
