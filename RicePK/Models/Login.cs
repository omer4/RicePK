using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RicePK.Models
{
    public class Login
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
    }
}