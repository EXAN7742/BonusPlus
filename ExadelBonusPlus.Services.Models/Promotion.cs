using System;
using System.Collections.Generic;

namespace ExadelBonusPlus.Services.Models
{
    public class Promotion
    {
 
        public string Name { get; set; }

        public string Description { get; set; }

        public int Vendor { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public int Estimate { get; set; }

        public Location Location { get; set; }

        public List<String> Tags { get; set; }
    }
}
