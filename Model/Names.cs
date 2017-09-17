using System;
using System.Collections.Generic;

namespace PCLItems.Core.Model
{
    public class Names
    {
        public Names()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int price { get; set; }
        public bool available { get; set; }
        public int preptime { get; set; }
        public List<string> Ingredients { get; set; }
        public bool isFavorite { get; set; }
        public string GroupName { get; set; }

    }
}
