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
            //switch(db.Friendrequests.Single(c => c.From.UserName == ThisUser && c.To.UserName == ProfileUser).)
            //{
            //    case "":

            //}






            if (db.Friendrequests.FirstOrDefault(c => c.From.UserName == ThisUser && c.To.UserName == ProfileUser) != null)
            {
                return "request";
            } else if(db.Friends.FirstOrDefault(c => c.User.UserName == ThisUser && c.AddedUser.UserName == ProfileUser) != null)
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
    }
}
