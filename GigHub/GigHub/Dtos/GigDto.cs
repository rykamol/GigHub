using System;

namespace GigHub.Dtos
{
    public class GigDto
    {
        public int Id { get; set; }

        public bool IsCanceled { get; set; }
        public ApplicationUserDto Artist { get; set; }
        public DateTime DateTime { get; set; }
        public string Vanue { get; set; }
        public GenreDto Genre { get; set; }
    }
}