using SW2_StoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW2_StoreProject.Security
{
    public class AuthorizationSecurity : IAuthorization
    {
        public bool checkRight(UserInfo userInfo)
        {
            //no need for more validation because it is already done in 
            return true;
        }
    }
}