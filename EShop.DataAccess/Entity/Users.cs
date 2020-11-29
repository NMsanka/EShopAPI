using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Data.Entity
{
    public class Users
    {
        [Description("Id")]
        public int Id { get; set; }
        
        [Description("Username")]
        public string Username { get; set; }

        [Description("Password")]
        public string Password { get; set; }        

    }
}
