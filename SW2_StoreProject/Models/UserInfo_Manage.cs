using SW2_StoreProject.DAL;
using SW2_StoreProject.Models;
using SW2_StoreProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW2_StoreProject.Models
{
    public class UserInfo_Manage : IUserInfo_Manage
    {
        private StoreContext db = new StoreContext();
        public IQueryable<UserInfo> getRegisteredUsers(UserInfo userObj)
        {
            //this means user is not logged in
            if(!userObj.IsLoggedIn)
                return null;

            IAuthorization authObj = new AuthorizationProxySecurity();
            //user not have permission to call this function
            if (!authObj.checkRight(userObj))
                return null;
            
            return db.UserInfos;
        }
    }
}