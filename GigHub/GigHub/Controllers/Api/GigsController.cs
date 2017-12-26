﻿using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    public class GigsController : ApiController
    {
        private ApplicationDbContext _context;

        public GigsController()
        {
            _context=new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId=User.Identity.GetUserId();
            var gigs = _context.Gigs.Single(x => x.Id == id && x.ArtistId == userId);

            if (gigs.IsCanceled)
            {
                return NotFound();
            }
            gigs.IsCanceled = true;
            _context.SaveChanges();
            return Ok();
        }
    }
}
