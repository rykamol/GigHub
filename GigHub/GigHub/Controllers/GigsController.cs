using GigHub.Models;
using GigHub.ViewModles;
using Microsoft.AspNet.Identity;
using System;
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
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var gigs = new Gig()
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = DateTime.Parse(string.Format("{0} {1}",viewModel.Date,viewModel.Time)),
                GenreId = viewModel.Genre,
                Vanue = viewModel.Vanue
            };

            Context.Gigs.Add(gigs);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}