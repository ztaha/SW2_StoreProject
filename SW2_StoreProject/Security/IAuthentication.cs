using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW2_StoreProject.Security
{
    public interface IAuthentication
    {
        bool validation(string email, string password);
    }
}