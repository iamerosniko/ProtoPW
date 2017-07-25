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
using ProjectWorkplace.Models;
using System.Web;

namespace ProjectWorkplace.Controllers
{
    public class resourcesController : ApiController
    {
        private ProjectWorkplaceContext db = new ProjectWorkplaceContext();

        // GET: api/resources
        public IQueryable<PW_resources> GetPW_resources()
        {
            return db.PW_resources;
        }

        [Route("api/resources/GetResourcePath")]
        public PW_GetResourcePath_Result GetResourcePath(string resourceCategory)
        {
            string currentDomainUser = HttpContext.Current.User.Identity.Name.ToString();
            //username only
            string currentUsername = currentDomainUser.Remove(0, currentDomainUser.IndexOf('\\') + 1);
            //this code is the integration of original PW_PERSONS TABLE and OTHER RELATIONAL TABLES
            var a = db.PW_GetResourcePath(currentUsername, resourceCategory).ToList();
            //this comming code is the temporary solution of registration side PW_TEMPORARY USERS
            //var a = db.PW_GetResourcePath2(currentUsername, resourceCategory).ToList();


            return (a.Count() > 0) ? a[0]  :
                new PW_GetResourcePath_Result ();

        }

        [Route("api/resources/GetResourcePath2")]
        public PW_GetResourcePath2_Result GetResourcePath2(string resourceCategory)
        {
            string currentDomainUser = HttpContext.Current.User.Identity.Name.ToString();
            //username only
            string currentUsername = currentDomainUser.Remove(0, currentDomainUser.IndexOf('\\') + 1);

            //this comming code is the temporary solution of registration side PW_TEMPORARY USERS
            var a = db.PW_GetResourcePath2(currentUsername, resourceCategory).ToList();


            return (a.Count() > 0) ? a[0] :
                new PW_GetResourcePath2_Result();

        }
        [Route("api/resources/GetVideo")]
        public PW_GetVideo_Result GetVideo(bool isLeader)
        {
            string currentDomainUser = HttpContext.Current.User.Identity.Name.ToString();
            //username only
            string currentUsername = currentDomainUser.Remove(0, currentDomainUser.IndexOf('\\') + 1);

            //this comming code is the temporary solution of registration side PW_TEMPORARY USERS
            var a = db.PW_GetVideo(currentUsername, isLeader).ToList();


            return (a.Count() > 0) ? a[0] :
                new PW_GetVideo_Result();

        }

        [Route("api/resources/GetCurrentUser")]
        public PW_GetCurrentUser_Result GetCurrentUser()
        {
            string currentDomainUser = HttpContext.Current.User.Identity.Name.ToString();
            //username only
            string currentUsername = currentDomainUser.Remove(0, currentDomainUser.IndexOf('\\') + 1);
            //this code is the integration of original PW_PERSONS TABLE and OTHER RELATIONAL TABLES
            var a = db.PW_GetCurrentUser(currentUsername).ToList();
            //this comming code is the temporary solution of registration side PW_TEMPORARY USERS
            //var a = db.PW_GetResourcePath2(currentUsername, resourceCategory).ToList();

            return (a.Count() > 0) ? a[0] :
                new PW_GetCurrentUser_Result();

        }
        
        // GET: api/resources/5
        [ResponseType(typeof(PW_resources))]
        public async Task<IHttpActionResult> GetPW_resources(Guid id)
        {
            PW_resources pW_resources = await db.PW_resources.FindAsync(id);
            if (pW_resources == null)
            {
                return NotFound();
            }

            return Ok(pW_resources);
        }
        
        // PUT: api/resources/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPW_resources(Guid id, PW_resources pW_resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pW_resources.ResourceID)
            {
                return BadRequest();
            }

            db.Entry(pW_resources).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PW_resourcesExists(id))
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

        // POST: api/resources
        [ResponseType(typeof(PW_resources))]
        public async Task<IHttpActionResult> PostPW_resources(PW_resources pW_resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PW_resources.Add(pW_resources);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PW_resourcesExists(pW_resources.ResourceID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pW_resources.ResourceID }, pW_resources);
        }

        // DELETE: api/resources/5
        [ResponseType(typeof(PW_resources))]
        public async Task<IHttpActionResult> DeletePW_resources(Guid id)
        {
            PW_resources pW_resources = await db.PW_resources.FindAsync(id);
            if (pW_resources == null)
            {
                return NotFound();
            }

            db.PW_resources.Remove(pW_resources);
            await db.SaveChangesAsync();

            return Ok(pW_resources);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PW_resourcesExists(Guid id)
        {
            return db.PW_resources.Count(e => e.ResourceID == id) > 0;
        }
    }
}