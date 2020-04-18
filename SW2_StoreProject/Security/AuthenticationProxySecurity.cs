using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW2_StoreProject.Security
{
    public class AuthenticationProxySecurity : IAuthentication
    {
        AuthenticationSecurity authObj = new AuthenticationSecurity();
        public bool validation(string email, string password) 
        {
            return authObj.validation(email, password);
        }
    }
}