using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhaleDateProject.Models;

namespace WhaleDateProject.Controllers
{
    public class PostController : ApiController
    {

        // POST: api/Post
        [HttpPost, ActionName("addPost")]
        public void addPost([FromBody] PostViewModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Posts.Add(new Post()
                {
                    Text = model.Text,
                    From = db.Users.Single(x=> x.UserName == model.FromUsername),
                    To = db.Users.Single(x => x.UserName == model.ToUsername),
                    Date = DateTime.Now
                });

                db.SaveChanges();
            }
        }
        
    }
}
