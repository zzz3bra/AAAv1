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
        //TODO: Adapt enum for our victim site, maybe split it for different sites to different classes
        public enum CarMarkListOnliner
        {
            Honda, BMW, Audi
        }
        public string[] PossibleMarks
        {
            get
            {
                return Enum.GetNames(typeof(CarMarkListOnliner));
            }
        }
        public string CarMark { get; set; }
        public string CarModel { get; set; }
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
            for (int i = 0; i < CarList.Length; i++)
            {
                if (CarList[i] != null)
                {
                    if (CarMark != null)
                    {
                        if (CarMark != CarList[i].Mark)
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
            cars.Add(new CarAd() { Mark = Enum.GetName(typeof(CarMarkListOnliner), 0), Model = "civka", Year = 1488, Price = 3700 });
            cars.Add(new CarAd() { Mark = Enum.GetName(typeof(CarMarkListOnliner), 1), Model = "318s", Year = 2008, Price = 37000 });
            cars.Add(new CarAd() { Mark = Enum.GetName(typeof(CarMarkListOnliner), 2), Model = "v8", Year = 1988, Price = 3700 });
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