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
    public class ServiceOrdersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ServiceOrders
        public IQueryable<ServiceOrder> GetServiceOrders()
        {
            return db.ServiceOrders;
        }

        // GET: api/ServiceOrders/5
        [ResponseType(typeof(ServiceOrder))]
        public async Task<IHttpActionResult> GetServiceOrder(Guid id)
        {
            ServiceOrder serviceOrder = await db.ServiceOrders.FindAsync(id);
            if (serviceOrder == null)
            {
                return NotFound();
            }

            return Ok(serviceOrder);
        }

        // PUT: api/ServiceOrders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutServiceOrder(Guid id, ServiceOrder serviceOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceOrder.Id)
            {
                return BadRequest();
            }

            db.Entry(serviceOrder).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceOrderExists(id))
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

        // POST: api/ServiceOrders
        [ResponseType(typeof(ServiceOrder))]
        public async Task<IHttpActionResult> PostServiceOrder(ServiceOrder serviceOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceOrders.Add(serviceOrder);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServiceOrderExists(serviceOrder.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = serviceOrder.Id }, serviceOrder);
        }

        // DELETE: api/ServiceOrders/5
        [ResponseType(typeof(ServiceOrder))]
        public async Task<IHttpActionResult> DeleteServiceOrder(Guid id)
        {
            ServiceOrder serviceOrder = await db.ServiceOrders.FindAsync(id);
            if (serviceOrder == null)
            {
                return NotFound();
            }

            db.ServiceOrders.Remove(serviceOrder);
            await db.SaveChangesAsync();

            return Ok(serviceOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceOrderExists(Guid id)
        {
            return db.ServiceOrders.Count(e => e.Id == id) > 0;
        }
    }
}