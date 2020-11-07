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
    public class post_categoryController : ApiController
    {
        private blogEntities db = new blogEntities();

        // GET: api/post_category
        public IQueryable<post_category> Getpost_category()
        {
            return db.post_category;
        }

        // GET: api/post_category/5
        [ResponseType(typeof(post_category))]
        public async Task<IHttpActionResult> Getpost_category(long id)
        {
            post_category post_category = await db.post_category.FindAsync(id);
            if (post_category == null)
            {
                return NotFound();
            }

            return Ok(post_category);
        }

        // PUT: api/post_category/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpost_category(long id, post_category post_category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post_category.id)
            {
                return BadRequest();
            }

            db.Entry(post_category).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!post_categoryExists(id))
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

        // POST: api/post_category
        [ResponseType(typeof(post_category))]
        public async Task<IHttpActionResult> Postpost_category(post_category post_category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.post_category.Add(post_category);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = post_category.id }, post_category);
        }

        // DELETE: api/post_category/5
        [ResponseType(typeof(post_category))]
        public async Task<IHttpActionResult> Deletepost_category(long id)
        {
            post_category post_category = await db.post_category.FindAsync(id);
            if (post_category == null)
            {
                return NotFound();
            }

            db.post_category.Remove(post_category);
            await db.SaveChangesAsync();

            return Ok(post_category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool post_categoryExists(long id)
        {
            return db.post_category.Count(e => e.id == id) > 0;
        }
    }
}