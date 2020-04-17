//123
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
    public class UserAccountController : ApiController
    {
        private StoreContext db = new StoreContext();

        // GET api/UserAccount
        public IQueryable<UserAccount> GetUserAccounts()
        {
            return db.UserAccounts;
        }

        // GET api/UserAccount/5
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult GetUserAccount(int id)
        {
            UserAccount useraccount = db.UserAccounts.Find(id);
            if (useraccount == null)
            {
                return NotFound();
            }

            return Ok(useraccount);
        }

        // PUT api/UserAccount/5
        public IHttpActionResult PutUserAccount(int id, [FromBody]UserAccount useraccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != useraccount.ID)
            {
                return BadRequest();
            }

            db.Entry(useraccount).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/UserAccount
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult PostUserAccount([FromBody]UserAccount useraccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserAccounts.Add(useraccount);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = useraccount.ID }, useraccount);
        }

        // DELETE api/UserAccount/5
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult DeleteUserAccount(int id)
        {
            UserAccount useraccount = db.UserAccounts.Find(id);
            if (useraccount == null)
            {
                return NotFound();
            }

            db.UserAccounts.Remove(useraccount);
            db.SaveChanges();

            return Ok(useraccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAccountExists(int id)
        {
            return db.UserAccounts.Count(e => e.ID == id) > 0;
        }
    }
}