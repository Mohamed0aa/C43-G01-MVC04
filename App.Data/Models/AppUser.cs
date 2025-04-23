using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Models
{
    public  class AppUser:IdentityUser
    {
        public string FirstName { set; get; }

        public string LastName { set; get; }
        public bool IsAgree { set; get; }
    }
}
