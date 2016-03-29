using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AAAv1.Models;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Newtonsoft.Json;

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


        public List<ADS> GetCarList()
        {
            GetDataOfCar Parser = new GetDataOfCar();
            List<ADS> ads = Parser.GetADS("");
            return ads;
        }

        private IEnumerable<SelectListItem> GetInfo()
        {
            var roles = FilteredCars
                .Manufacturers
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Value.OnlinerID.ToString(),
                                    Text = x.Key
                                });
            return new SelectList(roles, "Value", "Text");
        }        
       

        [HttpGet]
        public ViewResult CarForm()
        {
            FilteredCars searcher = new FilteredCars();
            searcher.CarManufacturers = GetInfo();
            searcher.ads = GetCarList();
            return View(searcher);
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