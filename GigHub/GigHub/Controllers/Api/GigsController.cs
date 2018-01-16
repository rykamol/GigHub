using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    public class GigsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context=new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId=User.Identity.GetUserId();
            var gigs = _context.Gigs
                .Include(g=>g.Attendences.Select(x=>x.Attendee))
                .Single(x => x.Id == id && x.ArtistId == userId);

            if (gigs.IsCanceled)
            {
                return NotFound();
            }
            gigs.Cencel();
            _context.SaveChanges();
            return Ok();
        }
    }
}
