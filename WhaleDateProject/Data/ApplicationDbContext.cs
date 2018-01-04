using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Data;
using Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Friend> Friends { get; set; }

        public DbSet<Friendrequest> Friendrequests { get; set; }

        public DbSet<Post> Posts { get; set; }



        public List<ApplicationUser> randomizeUser()
        {
            List<ApplicationUser> RandomUsers()
            {
                var list = new List<ApplicationUser>();
                var randomusers = Users.OrderBy(x => Guid.NewGuid()).ToList();
                list.Add(randomusers[0]);
                list.Add(randomusers[1]);
                list.Add(randomusers[2]);

                return list;

            }
            return RandomUsers();
        }

    }
    public class MyInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);

            var userManager = new ApplicationUserManager(store);

            for (int i = 0; i < 10; i++)
            {
                var user = new ApplicationUser { Firstname = "valFörnamn" + i, Lastname = "valEfternamn" + i, UserName = $"val{i}@val.se", Email = $"val{i}@val.se",
                    Gender = "Hane", InterestedIn = "Other", Private = true, ProfilePhoto = File.ReadAllBytes("val.jpg"), ContentType ="Test"};
                userManager.CreateAsync(user, "User1!").Wait();
            }


            base.Seed(context);
        }
    }

}