using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class FolloweesController : Controller
    {
        // GET: Followees
        private readonly ApplicationDbContext _context;

        public FolloweesController()
        {
            _context=new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId=User.Identity.GetUserId();
            var artists = _context.Followings
                .Where(u => u.FollowerId == userId)
                .Select(a=>a.Followee)
                .ToList();
            return View(artists);
        }
    }
}