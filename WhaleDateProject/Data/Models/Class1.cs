using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser AddedUser { get; set; }
    }
}
