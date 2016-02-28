using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AAAv1.Models
{
    public class FilteredCarsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            FilteredCars filter = value as FilteredCars;
            if (filter == null)
            {
                return false;
            }
            if (filter.CarYearHigh != null && filter.CarYearLow != null)
            {
                if (filter.CarYearLow > filter.CarYearHigh)
                {
                    ErrorMessage = "Введите корректный год";
                    return false;
                }
            }
            if (filter.CarPriceHigh != null && filter.CarPriceLow != null)
            {
                if (filter.CarPriceLow > filter.CarPriceHigh)
                {
                    ErrorMessage = "Введите корректный диапазон цен";
                    return false;
                }
            }
            return true;
        }
    }
}