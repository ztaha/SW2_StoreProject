using SW2_StoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW2_StoreProject.Security
{
    public class AuthorizationProxySecurity : IAuthorization
    {
        AuthorizationSecurity authObj = new AuthorizationSecurity();
        public bool checkRight(UserInfo userInfo)
        {
            if (userInfo.UserType == UserTypeEnum.Admin.ToDescriptionString())
            {
                return authObj.checkRight(userInfo);
            }
            else 
            {
                return false;
            }
        }
    }
}