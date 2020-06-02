using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JooleStoreApp.Models
{
    public class Consumer
    {
        [Required(ErrorMessage = "<i class=\"fas fa-exclamation-circle\"></i> Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "<i class=\"fas fa-exclamation-circle\"></i> Required")]
        public string UserEmail { get; set; }
        public string UserImage { get; set; }
        [Required(ErrorMessage = "<i class=\"fas fa-exclamation-circle\"></i> Required")]
        public string UserPassword { get; set; }
    }
}