using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmHub.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required (ErrorMessage ="Nhập UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Nhập Password")]
        public string PassWord { get; set; }

        public bool RememberMe {get;set;}

    }
}