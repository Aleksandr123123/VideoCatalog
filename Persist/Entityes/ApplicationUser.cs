using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persist.Entityes
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
