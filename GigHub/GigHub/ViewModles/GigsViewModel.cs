using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.ViewModles
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> UpComingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}