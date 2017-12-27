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
            ApplicationUser CurrentUser = db.Users.Single(x => x.UserName == ThisUser);
            ApplicationUser CurrentProfile = db.Users.Single(x => x.UserName == ProfileUser);
            
            if (db.Friendrequests.Single(x => x.From == CurrentUser && x.To == CurrentProfile) != null)
            {
                return "request";
            } else if(db.Friends.Where(x => x.User == CurrentUser && x.AddedUser == CurrentProfile) != null)
            {
                return "friend";
            } else
            {
                return "none";
            }
        
        }
    }
}
