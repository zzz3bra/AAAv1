using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AAAv1.Models;

namespace AAAv1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //TODO: Home page with Cars,Flats,BrownTaxes instead of redirect
            return RedirectFromIndexToForm();
        }
        public RedirectResult RedirectFromIndexToForm()
        {
            return RedirectPermanent("/Home/CarForm");
        }

        [HttpGet]
        public ViewResult CarForm()
        {
            return View();
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
                return View();
            }
        }
    }
}