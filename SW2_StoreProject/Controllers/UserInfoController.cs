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
using Newtonsoft.Json.Linq;

namespace SW2_StoreProject.Controllers
{
    public class UserInfoController : ApiController
    {
        private StoreContext db = new StoreContext();

        // GET api/UserInfo
        [ResponseType(typeof(UserInfo))]
        [Route("api/UserInfo/GetRegisteredUsers", Name = "GetRegisteredUsers")]
        [HttpGet]
        public IQueryable<UserInfo> GetRegisteredUsers(int id)
        {
            var message = string.Format("You are not log in or not have permission to call this api.");

            //return db.UserInfos;
            //check if user exist
            UserInfo userObj = db.UserInfos.Find(id);
            if (userObj == null) {                
                HttpError err = new HttpError(message);
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, err));
            }

            IUserInfo_Manage userManage = new UserInfo_Manage();
            var listUser = userManage.getRegisteredUsers(userObj);
            if (listUser == null)
            {
                HttpError err = new HttpError(message);
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, err));
            }

            return listUser;
        }

        // POST api/UserInfo
        [ResponseType(typeof(UserInfo))]
        [Route("api/UserInfo/Register", Name="Register")]
        [HttpPost]
        public IHttpActionResult Register([FromBody]UserInfo userInfo)
        {
            bool result = false;
            var message = string.Format("Operation failed, please check your email and password");
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.UserInfos.Add(UserInfo);
            //db.SaveChanges();
            IUserRegisteration userRegObj = new UserRegisteration();
            result = userRegObj.register(userInfo);

            if (!result) {
                HttpError err = new HttpError(message);
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, err));
            }

            //return CreatedAtRoute("DefaultApi", new { id = userInfo.ID }, userInfo);
            return StatusCode(HttpStatusCode.OK);
        }

        // POST api/UserInfo
        [Route("api/UserInfo/Login", Name = "Login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody]JObject data)
        {
            bool result = false;
            
            IUserLogin userLogin = new UserLogin();
            result = userLogin.login(((dynamic)data).email.Value.ToString(), ((dynamic)data).password.Value.ToString());

            if (result)
                return StatusCode(HttpStatusCode.OK);
            else
                return StatusCode(HttpStatusCode.NotFound);
        }

        // POST api/UserInfo
        [Route("api/UserInfo/LogOut", Name = "LogOut")]
        [HttpPost]
        public IHttpActionResult LogOut(int id)
        {
            var message = string.Format("You are not log in or not have permission to call this api.");
            //check if user exist
            UserInfo userObj = db.UserInfos.Find(id);
            if (userObj == null)
            {
                HttpError err = new HttpError(message);
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, err));
            }

            userObj.logOut();

            return StatusCode(HttpStatusCode.OK);
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