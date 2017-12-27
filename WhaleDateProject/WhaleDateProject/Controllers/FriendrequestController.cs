using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhaleDateProject.Controllers
{
    public class FriendrequestController : BaseController
    {
        // GET: Friendrequest
        public ActionResult Index(string Username)
        {
            ApplicationUser FromUser = db.Users.Single(x => x.UserName == User.Identity.Name);
            ApplicationUser ToUser = db.Users.Single(x => x.UserName == Username);
            Friendrequest friendrequest = new Friendrequest { From = FromUser, To = ToUser, Viewed = false };
            db.Friendrequests.Add(friendrequest);
            db.SaveChanges();
            return RedirectToAction("Profile", "Profile", routeValues: new { username = Username });
        }
    }
}