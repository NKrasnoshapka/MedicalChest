using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.DAL.IdentityModels
{
    public class JwtToken
    {
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }   
    }
}
