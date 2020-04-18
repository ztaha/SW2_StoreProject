using System;
using System.Web;
using System.Web.UI.WebControls;

namespace SW2_StoreProject.Models
{
    public interface IUserRegisteration
    {
        bool register(UserInfo userObj);
    }
}