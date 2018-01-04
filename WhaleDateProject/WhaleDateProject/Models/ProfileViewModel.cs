using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhaleDateProject.Models
{
    public class ProfileViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        
    }
}