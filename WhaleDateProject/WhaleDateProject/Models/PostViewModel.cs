using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhaleDateProject.Models
{
    public class PostViewModel
    {
        public string Text { get; set; }
        public string FromUsername { get; set; }
        public string ToUsername { get; set; }
    }
}