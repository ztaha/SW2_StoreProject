using SW2_StoreProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW2_StoreProject.Models
{
    public class UserInfo
    {
        private StoreContext db = new StoreContext();
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }        
        public string CreditId { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public bool IsLoggedIn { get; set; }
        public string UserType { get; set; }

        public UserInfo() {
            //default values
            IsLoggedIn = false;
            UserType = UserTypeEnum.Normal.ToDescriptionString();
        }
        
        public void logOut() {
            UserInfo userObj = db.UserInfos.Where(p => p.ID == this.ID).FirstOrDefault();
            userObj.IsLoggedIn = false;

            db.Entry(userObj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

    }
}
