using SW2_StoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW2_StoreProject.Models
{
    public interface IUserInfo_Manage
    {
        IQueryable<UserInfo> getRegisteredUsers(UserInfo userObj);
    }
}