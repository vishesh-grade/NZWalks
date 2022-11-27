using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repository
{
    public interface IRegionRepository
    {
        public Task<IEnumerable<Region>> GetAllAsync();
    }
}
