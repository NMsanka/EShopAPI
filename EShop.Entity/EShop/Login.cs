using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Entity.EShop
{
    public class LoginRequest
    {
        [Description("Username")]
        public string Username { get; set; }

        [Description("Password")]
        public string Password { get; set; }

    }

    public class LoginResponse
    {
        public bool IsSuccess { get; set; }

    }
}
