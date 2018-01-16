using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        
        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }
        
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Vanue { get; set; }

       
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public ICollection<Attendence> Attendences { get; set; }

        public Gig()
        {
            Attendences=new List<Attendence>();
        }

        public void Cencel()
        {
            IsCanceled = true;
            var aNotification = Notification.GigCanceled(this);

            foreach (var attendee in Attendences.Select(x => x.Attendee))
            {
                attendee.Notify(aNotification);
            }
        }

        public void Modify(string viewModelVanue, DateTime getDateTime, byte viewModelGenre)
        {
            var notification=Notification.GigUpdated(this,getDateTime,viewModelVanue);
            
            Vanue = viewModelVanue;
             DateTime = getDateTime;
            GenreId = viewModelGenre;

            foreach (var attendee in Attendences.Select(a=>a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}
