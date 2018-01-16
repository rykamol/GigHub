using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;

namespace GigHub.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}