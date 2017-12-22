using GigHub.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context=new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var allGigs = _context.Gigs
                .Include(g => g.Artist)
                .Where(d=>d.DateTime>DateTime.Now);
            return View(allGigs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}