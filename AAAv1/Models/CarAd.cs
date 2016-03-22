using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAAv1.Models
{
    public class CarAd
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public int? OnlinerAdID { get; set; }
        public int? AnotherSiteAdID { get; set; }
        public int InternalAdId { get; set; }
        public string URLAddress { get; set; }
    }
}