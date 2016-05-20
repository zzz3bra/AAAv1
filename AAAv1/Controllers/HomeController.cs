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
        FilteredCars currentResponse;
        List<ADS> currentADS;
        //Коннектимся к БД, открываемся юзера по умолчанию
        UserBase currentBase = UserBase.Instance;
        // GET: Home
        public ActionResult Index()
        {
            //TODO: Home page with Cars,Flats,BrownDachunds instead of redirect
            return RedirectFromIndexToForm();
        }
        public RedirectResult RedirectFromIndexToForm()
        {
            return RedirectPermanent("/Home/LoginForm");
        }
        [HttpGet]
        public ViewResult UserProfile()
        {
            return View("UserProfile", currentBase.CurrentUser);
        }
        [HttpGet]
        public ViewResult LoginForm()
        {
            LoginHelper loginer = new LoginHelper();
            return View(loginer);
        }
        [HttpPost]
        public ActionResult LoginForm(LoginHelper userResponse)
        {
            if (userResponse.CreateUser)
            {
                currentBase.AddUser(userResponse.Email, userResponse.Password);
                currentBase.CurrentUser = currentBase.GetUserByCredentials(userResponse.Email, userResponse.Password);
            }
            else
            {
                if ((currentBase.CurrentUser = currentBase.GetUserByCredentials(userResponse.Email, userResponse.Password)) == null)
                {
                    return View(new LoginHelper());
                }
            }
            return Redirect("CarForm");
        }
        [HttpGet]
        public ViewResult CarForm()
        {
            FilteredCars searcher = new FilteredCars(currentBase.CurrentUser.Email);
            return View(searcher);
        }

        [HttpPost]
        public ViewResult CarForm(FilteredCars userResponse)
        {
            if (ModelState.IsValid)
            {
                userResponse.GetCars();
                UserBase.Instance.CurrentUser.currentADS = userResponse.ads;
                return View("CarList", userResponse);
            }
            else
            {
                FilteredCars filter = new FilteredCars(currentBase.CurrentUser.Email);
                return View(filter);
            }
        }
        public EmptyResult AddFavouriteToUser(string carID)
        {
            currentBase.CurrentUser.AddFavouriteADS(UserBase.Instance.CurrentUser.currentADS.Find(item => item.Id.ToString() == carID));
            return new EmptyResult();
        }
    }
}