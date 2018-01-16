﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }
        
        [Required]
        public Gig Gig { get; private set; }

        public Notification()
        {
            
        }

        private Notification(NotificationType type,Gig gig)
        {
            if (gig==null)
            {
                throw new ArgumentNullException("gig");
            }
            DateTime=DateTime.Now;
            Gig = gig;
            Type = type;
        }

        public static Notification GigCreated(Gig gig)
        {
            return new Notification(NotificationType.GigCreated, gig);
        }
        public static Notification GigUpdated(Gig newGig,DateTime originalDate,string originalVanue)
        {
            var notification= new Notification(NotificationType.GigUpdate, newGig);
            notification.OriginalDateTime = originalDate;
            notification.OriginalVenue = originalVanue;

            return notification;
        }
        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(NotificationType.GigCanceled,gig);
        }


    }
}