using SW2_StoreProject.DAL;
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Linq;

namespace SW2_StoreProject.Models
{
    public class UserRegisteration : IUserRegisteration
    {
        private StoreContext db = new StoreContext();
        public bool register(UserInfo userObj)
        {
            int countRows = db.UserInfos.Where(p => p.Email == userObj.Email).Count();
            if (countRows > 0) {
                return false;
            }
 
            db.UserInfos.Add(userObj);
            db.SaveChanges();

            return true;
        }
    }
}