using GigHub.Models;
using GigHub.ViewModles;
using Microsoft.AspNet.Identity;
using System;
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
                .Include(a => a.Genre)
                .Include(a => a.Artist)
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
                Genres = Context.Genres.ToList(),
                Heading = "Create a Gig"
            };
            return View("GigForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = Context.Genres.ToList();
                return View("GigForm", viewModel);
            }
            var gigs = new Gig()
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Vanue = viewModel.Vanue,

            };

            Context.Gigs.Add(gigs);
            Context.SaveChanges();
            return RedirectToAction("MyUpcomingGigs", "Gigs");
        }

        [Authorize]
        public ActionResult MyUpcomingGigs()
        {
            var userId = User.Identity.GetUserId();
            var gigs = Context.Gigs
                .Where(g =>
                    g.ArtistId == userId
                    && g.DateTime > DateTime.Now
                    && !g.IsCanceled)
                .Include(g => g.Genre)
                .ToList();
            return View(gigs);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var gigs = Context.Gigs.Single(x => x.Id == id && x.ArtistId == userId);

            var viewModel = new GigFormViewModel
            {
                Genres = Context.Genres.ToList(),
                Date = gigs.DateTime.ToString("d MMM yyyy"),
                Time = gigs.DateTime.ToString("HH:mm"),
                Genre = gigs.GenreId,
                Vanue = gigs.Vanue,
                Id = gigs.Id,
                Heading = "Edit a Gig"

            };
            return View("GigForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = Context.Genres.ToList();
                return View("GigForm", viewModel);
            }
            var userId = User.Identity.GetUserId();
            var gigs = Context.Gigs
                .Include(x => x.Attendences.Select(a => a.Attendee))
                .Single(x => x.Id == viewModel.Id && x.ArtistId == userId);

            gigs.Modify(viewModel.Vanue, viewModel.GetDateTime(), viewModel.Genre);



            Context.SaveChanges();
            return RedirectToAction("MyUpcomingGigs", "Gigs");
        }
    }
}