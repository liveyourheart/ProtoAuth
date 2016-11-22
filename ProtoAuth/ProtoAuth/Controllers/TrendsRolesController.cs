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
    public class TrendsRolesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TrendsRoles
        public IQueryable<TrendsRole> GetTrendsRoles()
        {
            return db.TrendsRoles;
        }

        // GET: api/TrendsRoles/5
        [ResponseType(typeof(TrendsRole))]
        public async Task<IHttpActionResult> GetTrendsRole(int id)
        {
            TrendsRole trendsRole = await db.TrendsRoles.FindAsync(id);
            if (trendsRole == null)
            {
                return NotFound();
            }

            return Ok(trendsRole);
        }

        // PUT: api/TrendsRoles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrendsRole(int id, TrendsRole trendsRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trendsRole.Id)
            {
                return BadRequest();
            }

            db.Entry(trendsRole).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrendsRoleExists(id))
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

        // POST: api/TrendsRoles
        [ResponseType(typeof(TrendsRole))]
        public async Task<IHttpActionResult> PostTrendsRole(TrendsRole trendsRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrendsRoles.Add(trendsRole);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = trendsRole.Id }, trendsRole);
        }

        // DELETE: api/TrendsRoles/5
        [ResponseType(typeof(TrendsRole))]
        public async Task<IHttpActionResult> DeleteTrendsRole(int id)
        {
            TrendsRole trendsRole = await db.TrendsRoles.FindAsync(id);
            if (trendsRole == null)
            {
                return NotFound();
            }

            db.TrendsRoles.Remove(trendsRole);
            await db.SaveChangesAsync();

            return Ok(trendsRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrendsRoleExists(int id)
        {
            return db.TrendsRoles.Count(e => e.Id == id) > 0;
        }
    }
}