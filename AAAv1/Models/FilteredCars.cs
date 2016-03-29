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
            public int? InternalID { get; private set; }
            public int? OnlinerID { get; private set; }
            public int? AnotherSiteID { get; private set; }
            public string Name { get; private set; }
            public Model(string Name, int? InternalID, int? OnlinerID, int? AnotherSiteID)
            {
                this.Name = Name;
                this.InternalID = InternalID;
                this.OnlinerID = OnlinerID;
                this.AnotherSiteID = AnotherSiteID;
            }
        }
        public List<ADS> ads { get; set; }
        public static Dictionary<string, Manufacturer> Manufacturers
        {
            get; private set;
        }
        public static Dictionary<int, Model[]> Models
        {
            get; private set;
        }
        static FilteredCars()
        {
            Manufacturers = new Dictionary<string, Manufacturer>();
            Models = new Dictionary<int, Model[]>();
            Manufacturer empty = new Manufacturer("", 0, 0, null);
            Manufacturer honda = new Manufacturer("Honda", 1, 1, null);
            Manufacturer acura = new Manufacturer("Acura", 2, 2, null);
            Manufacturer bmw = new Manufacturer("BMW", 3, 3, null);
            Manufacturers.Add(empty.Name, empty);
            Models.Add(empty.OnlinerID.Value, new Model[1] { new Model(" ", 0, 0, 0) });
            Manufacturers.Add(honda.Name, honda);
            Models.Add(honda.OnlinerID.Value, new Model[3] { new Model("Civic", 0, 0, 0), new Model("Vshivik", 1, 1, 1), new Model("S2000", 2, 2, 2) });
            Manufacturers.Add(acura.Name, acura);
            Models.Add(acura.OnlinerID.Value, new Model[2] { new Model("Sakura", 0, 0, 0), new Model("NSX", 1, 1, 1) });
            Manufacturers.Add(bmw.Name, bmw);
            Models.Add(bmw.OnlinerID.Value, new Model[2] { new Model("318s", 0, 0, 0), new Model("520", 1, 1, 1) });
            //Initializing model lists, etc
        }
        //TODO: Adapt enum for our victim site, maybe split it for different sites to different classes
        public enum CarMarkListOnliner
        {
            Empty, Honda, Acura, BMW
        }
        public string SelectedCarManufacturerID { get; set; }
        public string SelectedCarModelID { get; set; }
        public IEnumerable<SelectListItem> CarManufacturers { get; set; }
        public int? CarYearLow { get; set; }
        public int? CarYearHigh { get; set; }
        public int? CarPriceLow { get; set; }
        public int? CarPriceHigh { get; set; }
        public CarAd[] CarList { get; private set; }
        public void GetCars()
        {
            //Here to be called ad grabber
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
                        if (SelectedCarManufacturerID != Manufacturers[CarList[i].Manufacturer].OnlinerID.ToString())
                        {
                            CarList[i] = null;
                        }
                    }
                }
            }
            #endregion
            #region Model
            if (!string.IsNullOrEmpty(SelectedCarModelID))
            {
                for (int i = 0; i < CarList.Length; i++)
                {
                    if (CarList[i] != null)
                    {
                        if (SelectedCarModelID != Models[int.Parse(SelectedCarManufacturerID)][int.Parse(SelectedCarModelID)].OnlinerID.ToString())
                        {
                            CarList[i] = null;
                        }
                    }
                }
            }
            #endregion
            #region Year
            if (CarYearHigh != null)
            {
                if (CarYearLow != null)
                {
                    for (int i = 0; i < CarList.Length; i++)
                    {
                        if (CarList[i] != null)
                        {
                            if (CarYearHigh < CarList[i].Year && CarYearLow > CarList[i].Year)
                            {
                                CarList[i] = null;
                            }
                        }
                    }
                }
                else {
                    for (int i = 0; i < CarList.Length; i++)
                    {
                        if (CarList[i] != null)
                        {
                            if (CarYearHigh < CarList[i].Year)
                            {
                                CarList[i] = null;
                            }
                        }
                    }
                }
            }
            else if (CarYearLow != null)
            {
                for (int i = 0; i < CarList.Length; i++)
                {
                    if (CarList[i] != null)
                    {
                        if (CarYearLow > CarList[i].Year)
                        {
                            CarList[i] = null;
                        }
                    }
                }
            }
            #endregion
            #region Price
            if (CarPriceHigh != null)
            {
                if (CarPriceLow != null)
                {
                    for (int i = 0; i < CarList.Length; i++)
                    {
                        if (CarList[i] != null)
                        {
                            if (CarPriceHigh < CarList[i].Price && CarPriceLow > CarList[i].Price)
                            {
                                CarList[i] = null;
                            }
                        }
                    }
                }
                else {
                    for (int i = 0; i < CarList.Length; i++)
                    {
                        if (CarList[i] != null)
                        {
                            if (CarPriceHigh < CarList[i].Price)
                            {
                                CarList[i] = null;
                            }
                        }
                    }
                }
            }
            else if (CarPriceLow != null)
            {
                for (int i = 0; i < CarList.Length; i++)
                {
                    if (CarList[i] != null)
                    {
                        if (CarPriceLow > CarList[i].Price)
                        {
                            CarList[i] = null;
                        }
                    }
                }
            }
            #endregion
            CarList = CarList.Where(c => c != null).ToArray();
        }
        private void FillCars()
        {
            List<CarAd> cars = new List<CarAd>();
#if DEBUG
            #region Debug list
            cars.Add(new CarAd() { Manufacturer = Enum.GetName(typeof(CarMarkListOnliner), 1), Model = "Civic", Year = 1488, Price = 3700 });
            cars.Add(new CarAd() { Manufacturer = Enum.GetName(typeof(CarMarkListOnliner), 3), Model = "318s", Year = 2008, Price = 37000 });
            cars.Add(new CarAd() { Manufacturer = Enum.GetName(typeof(CarMarkListOnliner), 3), Model = "520", Year = 1998, Price = 3700 });
            cars.Add(new CarAd() { Manufacturer = Enum.GetName(typeof(CarMarkListOnliner), 2), Model = "NSX", Year = 1988, Price = 9700 });
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