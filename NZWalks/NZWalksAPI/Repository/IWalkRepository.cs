using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repository
{
    public interface IWalkRepository
    {
        public Task<IEnumerable<Walk>> GetAllWalksAsync();
        public Task<Walk> GetWalkByID(Guid Id);
        public Task<Walk> AddWalk(Walk walk);
        public Task<Walk> DeleteWalk(Guid Id);
        public Task<Walk> UpdateWalk(Guid Id, Walk walk);
    }
}
