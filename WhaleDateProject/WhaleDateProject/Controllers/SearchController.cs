using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhaleDateProject.Controllers
{
    public class SearchController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string Searchstring)
        {
            var FoundProfiles = db.Users.Where(c => (c.Firstname.Contains(Searchstring) || c.Lastname.Contains(Searchstring)) && c.Private == false).ToList();
            return View(FoundProfiles);
        }
    }
}