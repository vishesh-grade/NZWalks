using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repository
{
    public interface IWalkDifficultyRepository
    {
        public Task<IEnumerable<WalkDifficulty>> GetAllWalkDifficultyAsync();

        public Task<WalkDifficulty> GetWalkDifficultyByID(Guid Id); 
    }
}
