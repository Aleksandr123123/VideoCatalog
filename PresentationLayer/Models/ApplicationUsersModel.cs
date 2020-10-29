using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class ApplicationUsersModel
    {
        public string Id { get; set; }
        public string UserName { get; set; } 
        public string Password { get; set; }

    }
    public class ApplicationUsersModelView
    {
        public string Id { get; set; }
        public string UserName { get; set; } 

    } 
}
