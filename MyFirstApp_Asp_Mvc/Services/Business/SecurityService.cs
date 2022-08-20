using MyFirstApp_Asp_Mvc.Models;
using MyFirstApp_Asp_Mvc.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstApp_Asp_Mvc.Services.Business
{
    public class SecurityService
    {
        SecurityDAO daoService = new SecurityDAO();

        public bool Authenticate(UserModel user)
        {
            return daoService.FindByUser(user);
        }
    }
}