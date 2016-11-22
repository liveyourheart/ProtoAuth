using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProtoAuth.Models;

namespace ProtoAuth.Controllers
{
    public class ClientUsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ClientUsers
        public IQueryable<ClientUser> GetClientUsers()
        {
            return db.ClientUsers;
        }

        // GET: api/ClientUsers/5
        [ResponseType(typeof(ClientUser))]
        public async Task<IHttpActionResult> GetClientUser(Guid id)
        {
            ClientUser clientUser = await db.ClientUsers.FindAsync(id);
            if (clientUser == null)
            {
                return NotFound();
            }

            return Ok(clientUser);
        }

        // PUT: api/ClientUsers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClientUser(Guid id, ClientUser clientUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientUser.Id)
            {
                return BadRequest();
            }

            db.Entry(clientUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientUserExists(id))
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

        // POST: api/ClientUsers
        [ResponseType(typeof(ClientUser))]
        public async Task<IHttpActionResult> PostClientUser(ClientUser clientUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientUsers.Add(clientUser);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClientUserExists(clientUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = clientUser.Id }, clientUser);
        }

        // DELETE: api/ClientUsers/5
        [ResponseType(typeof(ClientUser))]
        public async Task<IHttpActionResult> DeleteClientUser(Guid id)
        {
            ClientUser clientUser = await db.ClientUsers.FindAsync(id);
            if (clientUser == null)
            {
                return NotFound();
            }

            db.ClientUsers.Remove(clientUser);
            await db.SaveChangesAsync();

            return Ok(clientUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientUserExists(Guid id)
        {
            return db.ClientUsers.Count(e => e.Id == id) > 0;
        }
    }
}