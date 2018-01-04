using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Data.Models
{

    public class ApplicationUser : IdentityUser
    {
        
        public string Firstname { get; set; }

        public string Lastname { get; set; }
        public string Bio { get; set; }

        public string Age { get; set; }

        public string Type { get; set; }

        public string Gender { get; set; }

        public string InterestedIn { get; set; }

        public byte[] ProfilePhoto { get; set; }

        public bool Private { get; set; }

        public virtual ICollection<Friend> Friends { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }



}