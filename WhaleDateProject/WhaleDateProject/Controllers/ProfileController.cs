﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhaleDateProject.Controllers
{
    public class ProfileController : BaseController
    {
        [Authorize]
        public ActionResult Index(string username)
        {
            
            ApplicationUser user = db.Users.Single(x => x.UserName == username);
            
            return View(user);
        }

        [Authorize]
        public ActionResult Profile(string username)
        {
            if (username == User.Identity.Name)
            {
                return RedirectToAction("Index", "Profile", routeValues: new { username = User.Identity.Name });
            } else
            {
                ApplicationUser user = db.Users.Single(x => x.UserName == username);
                return View(user);
            }
            
        }
    }
}