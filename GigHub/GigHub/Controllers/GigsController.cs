using GigHub.Models;
using GigHub.ViewModles;
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
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = Context.Genres.ToList()
            };
            return View(viewModel);
        }
    }
}