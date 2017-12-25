using GigHub.Models;
using GigHub.ViewModles;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        public ApplicationDbContext Context;


        public GigsController()
        {
            Context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Attending()
        {
            string userId = User.Identity.GetUserId();

            var gigs = Context.Attendences.Where(a => a.AttendeeId == userId)
                .Select(g => g.Gig)
                .Include(a=>a.Genre)
                .Include(a=>a.Artist)
                .ToList();
            var viewModel = new GigsViewModel()
            {
                UpComingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gig's I'm Attending."
            };
            return View("Gigs", viewModel);
        }
        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = Context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = Context.Genres.ToList();
                return View("Create",viewModel);
            } 
            var gigs = new Gig()
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime =viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Vanue = viewModel.Vanue
            };

            Context.Gigs.Add(gigs);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}