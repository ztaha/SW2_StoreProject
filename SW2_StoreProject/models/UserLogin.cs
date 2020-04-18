using SW2_StoreProject.DAL;
using System;
using System.Web;
using System.Web.UI.WebControls;
using SW2_StoreProject.Security;

namespace SW2_StoreProject.Models
{
    public class UserLogin : IUserLogin
    {
        private StoreContext db = new StoreContext();
        public bool login(string email, string password)
        {
            IAuthentication userAuth = new AuthenticationProxySecurity();
            return userAuth.validation(email, password);
        }
    }
}