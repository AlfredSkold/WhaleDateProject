using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhaleDateProject.Models;
using System.Data.Entity;
using Data.Models;

namespace WhaleDateProject.Controllers
{
    public class FriendController : BaseController
    {
        // GET: Friend
        public ActionResult Index()
        {
            var FriendList = db.Friends.Include(x => x.User).ToList();
            
            return View(FriendList);
        }

        public ActionResult Delete(string username)
        {
            var Friendship = db.Friends.FirstOrDefault(c => c.User.UserName == User.Identity.Name && c.AddedUser.UserName == username);
            var AltFriendship = db.Friends.FirstOrDefault(c => c.AddedUser.UserName == User.Identity.Name && c.User.UserName == username);

            if(Friendship != null)
            {
                db.Friends.Remove(Friendship);
            } else
            {
                db.Friends.Remove(AltFriendship);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}