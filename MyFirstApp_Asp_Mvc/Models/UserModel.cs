using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstApp_Asp_Mvc.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserModel(int id, string userName, string password)
        {
            UserName = userName;
            Password = password;
            Id = id;
        }
        public UserModel()
        {
            Id = -1;
            UserName = "Nothing";
            Password = "Nothing yet";
           
        }
    }
}