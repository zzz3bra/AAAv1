using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AAAv1.Models;
using System.Web.UI.WebControls;

namespace AAAv1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //TODO: Home page with Cars,Flats,BrownDachunds instead of redirect
            return RedirectFromIndexToForm();
        }
        public RedirectResult RedirectFromIndexToForm()
        {
            return RedirectPermanent("/Home/CarForm");
        }

        private IEnumerable<SelectListItem> GetInfo()
        {
            var roles = FilteredCars
                .Manufacturers
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Key.OnlinerID.ToString(),
                                    Text = x.Key.Name
                                });
            return new SelectList(roles, "Value", "Text");
        }

        [HttpGet]
        public ViewResult CarForm()
        {
            FilteredCars filter = new FilteredCars();
            filter.CarManufacturers = GetInfo();
            return View(filter);
        }

        [HttpPost]
        public ViewResult CarForm(FilteredCars userResponse)
        {
            if (ModelState.IsValid)
            {
                userResponse.GetCars();
                return View("CarList", userResponse);
            }
            else
            {
                FilteredCars filter = new FilteredCars();
                filter.CarManufacturers = GetInfo();
                return View(filter);
            }
        }
    }
}