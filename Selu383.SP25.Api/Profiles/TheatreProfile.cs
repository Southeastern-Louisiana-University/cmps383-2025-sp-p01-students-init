using Selu383.SP25.Api.Entities;
using System.Runtime.InteropServices;
using AutoMapper;
namespace Selu383.SP25.Api.Profiles
    // Using the Profile for Automapper 
{
    public class TheatreProfile: Profile
    {
        public TheatreProfile()
        {
            CreateMap<Theater, TheaterDto>();
            CreateMap<TheaterCreateDto, Theater>();
            CreateMap<TheaterUpdateDto, Theater>();
            
        }

    }
}
