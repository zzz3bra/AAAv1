using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AAAv1.Models;
using System.Web.UI.WebControls;
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

        [HttpGet]
        public ViewResult CarForm()
        {
            FilteredCars searcher = new FilteredCars();
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
                return View(filter);
            }
        }
    }
}