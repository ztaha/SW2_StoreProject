using SW2_StoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW2_StoreProject.Security
{
    public interface IAuthorization
    {
        bool checkRight(UserInfo userInfo);
    }
}