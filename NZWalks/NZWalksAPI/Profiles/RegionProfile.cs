using AutoMapper;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Models.Domain.Region, Region>()
                .ReverseMap();
        }
    }
}
