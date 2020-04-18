using SW2_StoreProject.DAL;
using SW2_StoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW2_StoreProject.Security
{
    public class AuthenticationSecurity : IAuthentication
    {
        private StoreContext db = new StoreContext();
        public bool validation(string email, string password) {
            UserInfo userObj = db.UserInfos
                                .Where(p => p.Email == email && p.Password == password)
                                .FirstOrDefault();

            if (userObj != null) {
                userObj.IsLoggedIn = true;

                db.Entry(userObj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            else
                return false;
        }
    }
}