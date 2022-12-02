using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repository
{
    public interface IWalkDifficultyRepository
    {
        public Task<IEnumerable<WalkDifficulty>> GetAllWalkDifficultyAsync();

        public Task<WalkDifficulty> GetWalkDifficultyByID(Guid Id); 

        public Task<WalkDifficulty> AddWalkDifficulty(WalkDifficulty walkDifficulty);

        public Task<WalkDifficulty> DeleteWalkDifficulty(Guid Id);

        public Task<WalkDifficulty> UpdateWalkDifficulty(WalkDifficulty walkDifficulty , Guid Id);
    }
}
