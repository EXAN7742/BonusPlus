using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExadelBonusPlus.Services.Models
{
    public class Location
    {
        public string City { get; set; }

        public string Address { get; set; }

        public int Latitude { get; set; } //Ширина

        public int Longitude { get; set; } //Долгота

    }
}
