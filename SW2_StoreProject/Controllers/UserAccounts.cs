///Models/UserAccounts /// //public DbSet<UserAccount> UserAccounts { get; set; }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW2_StoreProject.Models
{
    public class UserAccount
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string CreditId { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public bool IsLoggedIn { get; set; }

    }
}
