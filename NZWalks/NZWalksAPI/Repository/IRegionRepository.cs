using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repository
{
    public interface IRegionRepository
    {
        public Task<IEnumerable<Region>> GetAllAsync();
        public Task<Region> GetAsync(Guid Id);
        public Task<Region> AddAsync(Region region);
        public Task<Region> DeleteAsync(Guid Id);
    }
}
