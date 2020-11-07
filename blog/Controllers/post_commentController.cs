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
    public class post_commentController : ApiController
    {
        private blogEntities db = new blogEntities();

        // GET: api/post_comment
        public IQueryable<post_comment> Getpost_comment()
        {
            return db.post_comment;
        }

        // GET: api/post_comment/5
        [ResponseType(typeof(post_comment))]
        public async Task<IHttpActionResult> Getpost_comment(long id)
        {
            post_comment post_comment = await db.post_comment.FindAsync(id);
            if (post_comment == null)
            {
                return NotFound();
            }

            return Ok(post_comment);
        }

        // PUT: api/post_comment/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpost_comment(long id, post_comment post_comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post_comment.id)
            {
                return BadRequest();
            }

            db.Entry(post_comment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!post_commentExists(id))
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

        // POST: api/post_comment
        [ResponseType(typeof(post_comment))]
        public async Task<IHttpActionResult> Postpost_comment(post_comment post_comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.post_comment.Add(post_comment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = post_comment.id }, post_comment);
        }

        // DELETE: api/post_comment/5
        [ResponseType(typeof(post_comment))]
        public async Task<IHttpActionResult> Deletepost_comment(long id)
        {
            post_comment post_comment = await db.post_comment.FindAsync(id);
            if (post_comment == null)
            {
                return NotFound();
            }

            db.post_comment.Remove(post_comment);
            await db.SaveChangesAsync();

            return Ok(post_comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool post_commentExists(long id)
        {
            return db.post_comment.Count(e => e.id == id) > 0;
        }
    }
}