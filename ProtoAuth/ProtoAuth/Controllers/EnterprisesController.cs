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
    public class EnterprisesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Enterprises
        public IQueryable<Enterprise> GetEnterprises()
        {
            return db.Enterprises;
        }

        // GET: api/Enterprises/5
        [ResponseType(typeof(Enterprise))]
        public async Task<IHttpActionResult> GetEnterprise(Guid id)
        {
            Enterprise enterprise = await db.Enterprises.FindAsync(id);
            if (enterprise == null)
            {
                return NotFound();
            }

            return Ok(enterprise);
        }

        // PUT: api/Enterprises/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEnterprise(Guid id, Enterprise enterprise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enterprise.Id)
            {
                return BadRequest();
            }

            db.Entry(enterprise).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnterpriseExists(id))
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

        // POST: api/Enterprises
        [ResponseType(typeof(Enterprise))]
        public async Task<IHttpActionResult> PostEnterprise(Enterprise enterprise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Enterprises.Add(enterprise);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EnterpriseExists(enterprise.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = enterprise.Id }, enterprise);
        }

        // DELETE: api/Enterprises/5
        [ResponseType(typeof(Enterprise))]
        public async Task<IHttpActionResult> DeleteEnterprise(Guid id)
        {
            Enterprise enterprise = await db.Enterprises.FindAsync(id);
            if (enterprise == null)
            {
                return NotFound();
            }

            db.Enterprises.Remove(enterprise);
            await db.SaveChangesAsync();

            return Ok(enterprise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnterpriseExists(Guid id)
        {
            return db.Enterprises.Count(e => e.Id == id) > 0;
        }
    }
}