using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAAv1.Models
{
    public class CarAd
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public int? OnlinerID { get; set; }
        public int? AnotherSiteID { get; set; }
        public string URLAddress { get; set; }
    }
}