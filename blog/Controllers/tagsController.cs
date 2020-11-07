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
using blog.Models;

namespace blog.Controllers
{
    public class tagsController : ApiController
    {
        private blogEntities db = new blogEntities();

        // GET: api/tags
        public IQueryable<tag> Gettag()
        {
            return db.tag;
        }

        // GET: api/tags/5
        [ResponseType(typeof(tag))]
        public async Task<IHttpActionResult> Gettag(long id)
        {
            tag tag = await db.tag.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

        // PUT: api/tags/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttag(long id, tag tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tag.id)
            {
                return BadRequest();
            }

            db.Entry(tag).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tagExists(id))
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

        // POST: api/tags
        [ResponseType(typeof(tag))]
        public async Task<IHttpActionResult> Posttag(tag tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tag.Add(tag);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tag.id }, tag);
        }

        // DELETE: api/tags/5
        [ResponseType(typeof(tag))]
        public async Task<IHttpActionResult> Deletetag(long id)
        {
            tag tag = await db.tag.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            db.tag.Remove(tag);
            await db.SaveChangesAsync();

            return Ok(tag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tagExists(long id)
        {
            return db.tag.Count(e => e.id == id) > 0;
        }
    }
}