using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository
    {
        public static string UserAdded(string ThisUser, string ProfileUser)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (db.Friendrequests.FirstOrDefault(c => c.From.UserName == ThisUser && c.To.UserName == ProfileUser) != null)
            {
                return "request";
            } else if (db.Friends.FirstOrDefault(c => c.User.UserName == ThisUser && c.AddedUser.UserName == ProfileUser) != null)
            {
                return "friend";
            } else if (db.Friends.FirstOrDefault(c => c.AddedUser.UserName == ThisUser && c.User.UserName == ProfileUser) != null)
            {
                return "friend";
            } else if(db.Friendrequests.FirstOrDefault(c => c.To.UserName == ThisUser && c.From.UserName == ProfileUser) != null)
            {
                return "requesttome";
            } else
            {
                return "none";
            }
        }

        public static int NewRequests(string ThisUser)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            int i = 0;
            foreach (var item in db.Friendrequests.Where(c => c.To.UserName == ThisUser).ToList())
            {
                if (item.Viewed == false)
                    i++;
            }
            return i;
        }

        public static bool isLoggedIn(string ThisUser)
        {
            if(ThisUser != null)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}
