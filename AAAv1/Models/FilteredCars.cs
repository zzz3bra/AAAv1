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
        public List<ADS> ads { get; set; }
        public List<string> Manufacturers
        {
            get; private set;
        }
        public Dictionary<string, string[]> Models
        {
            get; private set;
        }
        public FilteredCars()
        {
            Manufacturers = new List<string>();
            Models = new Dictionary<string, string[]>();
            Manufacturers.Add("Honda");
            Manufacturers.Add("BMW");
            Manufacturers.Add("Nissan");
            Manufacturers.Add("Audi");
            Manufacturers.Add("Volkswagen");
            Manufacturers.Add("Mercedes");
            Manufacturers.Add("Lexus");
            Manufacturers.Add("Mitsubishi");
            Manufacturers.Add("Hyundai");
            Manufacturers.Add("Fiat");
            Manufacturers.Add("Renault");
            Manufacturers.Add("Espace");
            Manufacturers.Add("Acura");
            Manufacturers.Add("Land");
            Manufacturers.Add("Range");
            Manufacturers.Add("Evoque");
            Manufacturers.Add("Opel");
            Manufacturers.Add("Porsche");
            Manufacturers.Add("Chrysler");
            Manufacturers.Add("Mazda");
            Manufacturers.Add("Subaru");
            Manufacturers.Add("Chevrolet");
            Manufacturers.Add("Chery");
            Manufacturers.Add("Toyota");
            Manufacturers.Add("Geely");
            Manufacturers.Add("Peugeot");
            Manufacturers.Add("Skoda");
            Manufacturers.Add("Caravelle");
            Manufacturers.Add("Citroen");
            Manufacturers.Add("Cadillac");
            Models.Add("Honda", new string[3] { "Civic", "Vshivik", "S2000" });
            Models.Add("Acura", new string[2] { "Sakura", "Figura" });
            Models.Add("BMW", new string[6] { "318s", "520", "550", "X3", "X5", "X6" });
            Manufacturers.Sort();
        }
        public enum CarMarkListOnliner
        {
            Empty, Honda, Acura, BMW
        }
        public string SelectedCarManufacturer { get; set; }
        public string SelectedCarModel { get; set; }
        public int? CarYearLow { get; set; }
        public int? CarYearHigh { get; set; }
        public int? CarPriceLow { get; set; }
        public int? CarPriceHigh { get; set; }
        public void GetCars()
        {
            FillCars();
            FilterCars();
        }
        public void FilterCars()
        {
            #region Mark
            if (!string.IsNullOrEmpty(SelectedCarManufacturer))
            {
                for (int i = 0; i < ads.Count; i++)
                {
                    if (ads[i] != null)
                    {
                        if (SelectedCarManufacturer != ads[i].Car.Model.ManufacturerName)
                        {
                            ads[i] = null;
                        }
                    }
                }
            }
            #endregion
            #region Model
            if (!string.IsNullOrEmpty(SelectedCarModel))
            {
                for (int i = 0; i < ads.Count; i++)
                {
                    if (ads[i] != null)
                    {
                        if (SelectedCarModel != ads[i].Car.Model.Name)
                        {
                            ads[i] = null;
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
                    for (int i = 0; i < ads.Count; i++)
                    {
                        if (ads[i] != null)
                        {
                            if (CarYearHigh < int.Parse(ads[i].Car.Year) && CarYearLow > int.Parse(ads[i].Car.Year))
                            {
                                ads[i] = null;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < ads.Count; i++)
                    {
                        if (ads[i] != null)
                        {
                            if (CarYearHigh < int.Parse(ads[i].Car.Year))
                            {
                                ads[i] = null;
                            }
                        }
                    }
                }
            }
            else if (CarYearLow != null)
            {
                for (int i = 0; i < ads.Count; i++)
                {
                    if (ads[i] != null)
                    {
                        if (CarYearLow > int.Parse(ads[i].Car.Year))
                        {
                            ads[i] = null;
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
                    for (int i = 0; i < ads.Count; i++)
                    {
                        if (ads[i] != null)
                        {
                            if (CarPriceHigh < int.Parse(ads[i].Car.Price) && CarPriceLow > int.Parse(ads[i].Car.Price))
                            {
                                ads[i] = null;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < ads.Count; i++)
                    {
                        if (ads[i] != null)
                        {
                            if (CarPriceHigh < int.Parse(ads[i].Car.Price))
                            {
                                ads[i] = null;
                            }
                        }
                    }
                }
            }
            else if (CarPriceLow != null)
            {
                for (int i = 0; i < ads.Count; i++)
                {
                    if (ads[i] != null)
                    {
                        if (CarPriceLow > int.Parse(ads[i].Car.Price))
                        {
                            ads[i] = null;
                        }
                    }
                }
            }
            #endregion
            ads.RemoveAll(item => item == null);
        }
        private void FillCars()
        {
            GetDataOfCar Parser = new GetDataOfCar();
            ads = Parser.GetADS("");
            //ads.AddRange(Parser.GetADS(UserBase.MockUser.GetIdealCar().ToString()));
#if DEBUG
            #region Debug list
            //cars.Add(new CarAd() { Manufacturer = Enum.GetName(typeof(CarMarkListOnliner), 1), Model = "Civic", Year = 1488, Price = 3700 });
            #endregion
#else
            #region Release list
            //cars.Add(new CarAd() { Mark = "release", Model = "final", Year = 2016, Price = int.MaxValue });
            #endregion
#endif
        }
    }
}