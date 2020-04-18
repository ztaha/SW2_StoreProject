using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SW2_StoreProject.Models;
using SW2_StoreProject.DAL;

namespace SW2_StoreProject.Controllers
{
    public class UserInfoController : ApiController
    {
        private StoreContext db = new StoreContext();

        // GET api/UserInfo
        public IQueryable<UserInfo> GetUserInfos(int userId)
        {
            //return db.UserInfos;
            //check if user exist
            UserInfo userObj = db.UserInfos.Find(userId);
            if (userObj == null)
                return null;

            IUserInfo_Manage userManage = new UserInfo_Manage();
            return userManage.getRegisteredUsers(userObj);
        }

        // POST api/UserInfo
        [ResponseType(typeof(UserInfo))]
        [Route("api/UserInfo")]
        [HttpPost]
        public IHttpActionResult Register([FromBody]UserInfo UserInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserInfos.Add(UserInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = UserInfo.ID }, UserInfo);
        }
        
        //close database connection
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}