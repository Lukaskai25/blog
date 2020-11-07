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
    public class post_tagController : ApiController
    {
        private blogEntities db = new blogEntities();

        // GET: api/post_tag
        public IQueryable<post_tag> Getpost_tag()
        {
            return db.post_tag;
        }

        // GET: api/post_tag/5
        [ResponseType(typeof(post_tag))]
        public async Task<IHttpActionResult> Getpost_tag(long id)
        {
            post_tag post_tag = await db.post_tag.FindAsync(id);
            if (post_tag == null)
            {
                return NotFound();
            }

            return Ok(post_tag);
        }

        // PUT: api/post_tag/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpost_tag(long id, post_tag post_tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post_tag.id)
            {
                return BadRequest();
            }

            db.Entry(post_tag).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!post_tagExists(id))
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

        // POST: api/post_tag
        [ResponseType(typeof(post_tag))]
        public async Task<IHttpActionResult> Postpost_tag(post_tag post_tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.post_tag.Add(post_tag);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = post_tag.id }, post_tag);
        }

        // DELETE: api/post_tag/5
        [ResponseType(typeof(post_tag))]
        public async Task<IHttpActionResult> Deletepost_tag(long id)
        {
            post_tag post_tag = await db.post_tag.FindAsync(id);
            if (post_tag == null)
            {
                return NotFound();
            }

            db.post_tag.Remove(post_tag);
            await db.SaveChangesAsync();

            return Ok(post_tag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool post_tagExists(long id)
        {
            return db.post_tag.Count(e => e.id == id) > 0;
        }
    }
}