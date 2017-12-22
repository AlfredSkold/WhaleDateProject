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

            List<Friend> allFriends = new List<Friend>();

            foreach (var Friend in FriendList)
            {
                if(Friend.User.UserName == User.Identity.Name)
                {
                    allFriends.Add(Friend);
                }
            }

            return View(allFriends);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Friend friend)
        {
            var ThisUser = db.Users.Single(x => x.UserName == User.Identity.Name);
            var FriendUser = db.Users.Single(x => x.UserName == friend.Email);
            Friend newFriend = new Friend() { Email = friend.Email, User = ThisUser, AddedUser = FriendUser };
            db.Friends.Add(newFriend);
            db.SaveChanges();
            ViewBag.Title = "Vänförfrågan Skickad!";
            return View();
        }
        
        
        public ActionResult Delete(int id)
        {
            Friend Friendship = db.Friends.Single(x => x.Id == id);


            db.Friends.Remove(Friendship);
            db.SaveChanges();
            return View("Create", "Friend");
        }
    }
}