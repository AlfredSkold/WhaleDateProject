using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Friendrequest
    {
        public int Id { get; set; }
        public ApplicationUser From { get; set; }
        public ApplicationUser To { get; set; }
        public bool Viewed { get; set; }
    }
}
