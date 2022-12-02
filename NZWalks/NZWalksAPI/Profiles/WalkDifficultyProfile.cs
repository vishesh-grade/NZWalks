using AutoMapper;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Profiles
{
    public class WalkDifficultyProfile: Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<Models.Domain.WalkDifficulty, WalkDifficulty>()
                .ReverseMap();
        }
    }
}
