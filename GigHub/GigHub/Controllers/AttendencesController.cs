using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendencesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AttendencesController()
        {
            _context=new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendenceDto dto)
        {
            var userId= User.Identity.GetUserId();

            if (_context.Attendences.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
            {
                return BadRequest("The attendence is already exists");
            }
            var attendence = new Attendence
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendences.Add(attendence);
            _context.SaveChanges();
            return Ok();
        }
    }
}
