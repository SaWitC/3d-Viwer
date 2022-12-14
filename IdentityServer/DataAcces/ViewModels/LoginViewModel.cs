using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.ViewModels
{
    public  class LoginViewModel
    {
        [Required]
        [MinLength(5),MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
