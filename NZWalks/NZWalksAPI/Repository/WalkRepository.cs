using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Walk> AddWalk(Walk walk)
        {
            walk.Id = Guid.NewGuid();
           await nZWalksDbContext.Walks.AddAsync(walk);
            await nZWalksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllWalksAsync()
        {
            return await nZWalksDbContext.Walks.
                Include(x=>x.Region).
                Include(x=>x.WalkDifficulty).
                ToListAsync();
        }

        public async Task<Walk> GetWalkByID(Guid Id)
        {
            return await nZWalksDbContext.Walks.
                Include(x => x.Region).
                Include(x => x.WalkDifficulty).
                FirstOrDefaultAsync(x => x.Id== Id);
        }
    }
}
