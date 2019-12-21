using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelAgency.Web.Areas.Admin.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        public string Login { set; get; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}