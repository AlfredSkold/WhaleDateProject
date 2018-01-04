using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Post
    {
        public int Id { get; set; }

        //[Display(Name = "Typ")]
        //[Required(ErrorMessage = "Skriv något i ditt meddelande!")]
        public string Text { get; set; }

        public ApplicationUser From { get; set; }
        public ApplicationUser To { get; set; }
        public DateTime Date { get; set; }
    }
}
