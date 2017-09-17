using System;
using System.Collections.Generic;

namespace PCLItems.Core.Model
{
    public class NameGroup
    {
        public NameGroup()
        {
        }

        public int GroupId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public List<Names> Names { get; set; }
    }
}
