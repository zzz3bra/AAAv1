using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AAAv1.Models
{
    [FilteredCars]
    public class FilteredCars
    {
        public class Manufacturer
        {
            public int? InternalID { get; private set; }
            public int? OnlinerID { get; private set; }
            public int? AnotherSiteID { get; private set; }
            public string Name { get; private set; }
            public Manufacturer(string Name, int? InternalID, int? OnlinerID, int? AnotherSiteID)
            {
                this.Name = Name;
                this.InternalID = InternalID;
                this.OnlinerID = OnlinerID;
                this.AnotherSiteID = AnotherSiteID;
            }
        }
        public class Model
        {
            public int? OnlinerID { get; private set; }
            public int? AnotherSiteID { get; private set; }
            public string Name { get; private set; }
        }
        public static Dictionary<Manufacturer, string> Manufacturers
        {
            get; private set;
        }
        public static Dictionary<Manufacturer, Model[]> Models
        {
            get; private set;
        }
        static FilteredCars()
        {
            Manufacturers = new Dictionary<Manufacturer, string>();
            Manufacturer empty = new Manufacturer("", null, null, null);
            Manufacturer honda = new Manufacturer("Honda", 1, 1, null);
            Manufacturer acura = new Manufacturer("Acura", 2, 2, null);
            Manufacturer bmw = new Manufacturer("BMW", 3, 3, null);
            Manufacturers.Add(empty, empty.Name);
            Manufacturers.Add(honda, honda.Name);
            Manufacturers.Add(acura, acura.Name);
            Manufacturers.Add(bmw, bmw.Name);
            //Initializing lists, etc
        }
        //TODO: Adapt enum for our victim site, maybe split it for different sites to different classes
        public enum CarMarkListOnliner
        {
            Empty, Honda, Acura, BMW
        }
        public string SelectedCarManufacturerID { get; set; }
        public Manufacturer SelectedCarManufacturer { get; set; }
        public IEnumerable<SelectListItem> CarManufacturers { get; set; }
        public Model CarModel { get; set; }
        public int? CarYearLow { get; set; }
        public int? CarYearHigh { get; set; }
        public int? CarPriceLow { get; set; }
        public int? CarPriceHigh { get; set; }
        public CarAd[] CarList { get; private set; }
        public void GetCars()
        {
            FillCars();
            FilterCars();
        }
        public void FilterCars()
        {
            #region Mark
            if (!string.IsNullOrEmpty(SelectedCarManufacturerID))
            {
                for (int i = 0; i < CarList.Length; i++)
                {
                    if (CarList[i] != null)
                    {
                        if (SelectedCarManufacturerID != CarList[i].OnlinerID.ToString())
                        {
                            CarList[i] = null;
                        }
                    }
                }
            }
            #endregion
            #region Model
            //TODO: filter by model
            #endregion
            #region Year
            //TODO: filter by year
            #endregion
            #region Price
            //TODO: filter by price
            #endregion
        }
        private void FillCars()
        {
            List<CarAd> cars = new List<CarAd>();
#if DEBUG
            #region Debug list
            cars.Add(new CarAd() { Mark = Enum.GetName(typeof(CarMarkListOnliner), 1), Model = "civka", Year = 1488, Price = 3700, OnlinerID = 1 });
            cars.Add(new CarAd() { Mark = Enum.GetName(typeof(CarMarkListOnliner), 3), Model = "318s", Year = 2008, Price = 37000, OnlinerID = 3 });
            cars.Add(new CarAd() { Mark = Enum.GetName(typeof(CarMarkListOnliner), 2), Model = "v8", Year = 1988, Price = 3700, OnlinerID = 2 });
            #endregion
#else
            #region Release list
            //TODO: some JSON parsing and data grabbing
            cars.Add(new CarAd() { Mark = "release", Model = "final", Year = 2016, Price = int.MaxValue });
            #endregion
#endif
            CarList = cars.ToArray();
        }
    }
}