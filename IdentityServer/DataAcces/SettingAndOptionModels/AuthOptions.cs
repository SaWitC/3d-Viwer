using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace DataAcces.SettingAndOptionModels
{
    public class AuthOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Secret { get; set; }
        public int TokenLifeTime { get; set; }

        public SymmetricSecurityKey GetSymetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
