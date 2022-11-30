using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repository
{
    public interface IWalkRepository
    {
        public Task<IEnumerable<Walk>> GetAllWalksAsync();
    }
}
