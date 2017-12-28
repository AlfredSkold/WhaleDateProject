using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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

        public ActionResult RequestList()
        {

            var requests = db.Friendrequests.Include(y => y.From).Where(y => y.To.UserName == User.Identity.Name);
            foreach (var item in requests)
            {
                if(item.Viewed == false)
                {
                    item.Viewed = true;
                }
            }
            db.SaveChanges();
            return View(requests);
        }

        public ActionResult Ignore(string username)
        {
            var request = db.Friendrequests.Single(c => c.From.UserName == username && c.To.UserName == User.Identity.Name);
            db.Friendrequests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("RequestList");
        }

        public ActionResult Accept(string username)
        {
            var request = db.Friendrequests.Single(c => c.From.UserName == username && c.To.UserName == User.Identity.Name);


            var friendship = new Friend { User = db.Users.Single(c => c.UserName == username), AddedUser = db.Users.Single(c => c.UserName == User.Identity.Name) };

            db.Friends.Add(friendship);
            db.Friendrequests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("RequestList");
        }
    }
}