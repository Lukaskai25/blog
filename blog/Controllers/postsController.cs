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
    public class postsController : ApiController
    {
        private blogEntities db = new blogEntities();

        // GET: api/posts
        public IQueryable<post> Getpost()
        {
            return db.post;
        }

        // GET: api/posts/5
        [ResponseType(typeof(post))]
        public async Task<IHttpActionResult> Getpost(long id)
        {
            post post = await db.post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/posts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpost(long id, post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.id)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!postExists(id))
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

        // POST: api/posts
        [ResponseType(typeof(post))]
        public async Task<IHttpActionResult> Postpost(post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.post.Add(post);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = post.id }, post);
        }

        // DELETE: api/posts/5
        [ResponseType(typeof(post))]
        public async Task<IHttpActionResult> Deletepost(long id)
        {
            post post = await db.post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            db.post.Remove(post);
            await db.SaveChangesAsync();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool postExists(long id)
        {
            return db.post.Count(e => e.id == id) > 0;
        }
    }
}