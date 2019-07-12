using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SayMore.Models
{
    public class LoginModel
    {

        [StringLength(100)]
        public string Email { get; set; }


        [StringLength(50)]
        public string Password { get; set; }

        
    }
}