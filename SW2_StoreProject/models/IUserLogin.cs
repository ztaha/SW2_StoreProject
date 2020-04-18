using System;
using System.Web;
using System.Web.UI.WebControls;

namespace SW2_StoreProject.Models
{
    public interface IUserLogin
    {
        bool login(string email, string password);
    }
}