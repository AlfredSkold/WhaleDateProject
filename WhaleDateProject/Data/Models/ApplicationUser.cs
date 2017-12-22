using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Data.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public string Surname { get; set; }
        
        public string Lastname { get; set; }


        public string Bio { get; set; }
        
        [DataType(DataType.MultilineText)]
        public Gender Gender { get; set; }
        
        [DataType(DataType.MultilineText)]
        public Gender InterestedIn { get; set; }

        public virtual ICollection<Friend> Friends { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Surname", Surname));
            return userIdentity;
        }
    }

    

    public enum Gender
    {
        Male,
        Female,
        Other
    }


}