using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePay.Entity
{
    public class Auth
    {     
        public int Id_auth { get; set; }
        public Employee User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int InAdmin { get; set; }
    }
}
