using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacefinderApp.Data.Models
{
    class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int MyProperty { get; set; }
        public string RNumber { get; set; }


    }
}
