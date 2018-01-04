using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhaleDateProject.Models;
using System.Data.Entity;

namespace WhaleDateProject.Controllers
{
    public class ProfileController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            
            ApplicationUser user = db.Users.Single(x => x.UserName == User.Identity.Name);
            
            var posts = db.Posts.Include(c => c.From).Where(x => x.To.UserName == user.UserName).ToList();
            

            ProfileViewModel ViewModel = new ProfileViewModel { User = user, Posts = posts };
            return View(ViewModel);
        }

        [Authorize]
        public ActionResult Profile(string username)
        {

            if (username == User.Identity.Name)
            {
                return RedirectToAction("Index", "Profile", routeValues: new { username = User.Identity.Name });
            }
            else
            {
                ApplicationUser user = db.Users.Single(x => x.UserName == username);
                var posts = db.Posts.Include(c => c.From).Where(x => x.To.UserName == username).ToList().OrderByDescending(t => t.Date);

                //ApplicationUser fakeUser = db.Users.Single(x => x.Firstname == "valFörnamn5");

                //Post post = new Post { From = fakeUser, To = user, Text = "TJABBBABJABETJTEJHRJERHJAHRJA", Date = DateTime.Now };

                //db.Posts.Add(post);
                //db.SaveChanges();

                ProfileViewModel ViewModel = new ProfileViewModel { User = user, Posts = posts };
                
                return View(ViewModel);
            }

        }

        public ActionResult Image(string username)
        {
            var user = db.Users.Single(c => c.UserName == username);

            return File(user.ProfilePhoto, user.ContentType);
        }
    }
}