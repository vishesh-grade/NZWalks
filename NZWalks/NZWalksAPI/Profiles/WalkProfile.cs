using AutoMapper;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Profiles
{
    public class WalkProfile : Profile
    {
       public WalkProfile()
            {
            CreateMap<Models.Domain.Walk, Walk>()
                    .ReverseMap();
            }
        }
    }

