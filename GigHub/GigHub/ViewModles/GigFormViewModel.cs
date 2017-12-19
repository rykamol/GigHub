using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.ViewModles
{
    public class GigFormViewModel
    {
        public string Vanue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

    }
}