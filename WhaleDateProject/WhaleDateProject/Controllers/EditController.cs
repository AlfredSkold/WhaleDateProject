
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Data.Models;

namespace WhaleDateProject.Controllers
{
    public class EditController : BaseController
    {
        [HttpPost]
        public ActionResult Photo(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                var thisUser = db.Users.Single(c => c.UserName == User.Identity.Name);

                thisUser.Filename = upload.FileName;
                thisUser.ContentType = upload.ContentType;

                using (var reader = new BinaryReader(upload.InputStream))
                {
                    thisUser.ProfilePhoto = reader.ReadBytes(upload.ContentLength);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Profile", new { username = User.Identity.Name });
        }
        [HttpPost]
        public ActionResult Info(ApplicationUser user)
        {
            var thisUser = db.Users.Single(c => c.UserName == User.Identity.Name);

            thisUser.Age = user.Age;
            thisUser.Type = user.Type;
            thisUser.Gender = user.Gender;
            thisUser.InterestedIn = user.InterestedIn;
            thisUser.Private = user.Private;
            //if (Private== true)
            //{
            //    thisUser.Private = true;
            //} else
            //{
            //    thisUser.Private = false;
            //}

            db.SaveChanges();

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult Bio(ApplicationUser user)
        {
            var thisUser = db.Users.Single(c => c.UserName == User.Identity.Name);

            thisUser.Bio = user.Bio;
            db.SaveChanges();
            return RedirectToAction("Index", "Profile");
        }
    }
}