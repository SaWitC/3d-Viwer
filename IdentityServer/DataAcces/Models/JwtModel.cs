using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Models
{
    public class JwtModel
    {
        [Key]
        public string jwtTokenId { get; set; }
    }
}
