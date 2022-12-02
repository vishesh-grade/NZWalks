using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repository
{
    public class WalkDifficultyRepository: IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkDifficultyRepository(NZWalksDbContext nZWalksDbContext) {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<WalkDifficulty> AddWalkDifficulty(WalkDifficulty walkDifficulty)
        {
            await nZWalksDbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await nZWalksDbContext.SaveChangesAsync();

            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteWalkDifficulty(Guid Id)
        {
            var wD = await nZWalksDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == Id);
            if(wD == null)
            {
                return null;
            }
            nZWalksDbContext.WalkDifficulty.Remove(wD);
            await nZWalksDbContext.SaveChangesAsync();

            return wD;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllWalkDifficultyAsync()
        {
          return await nZWalksDbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetWalkDifficultyByID(Guid Id)
        {
            return await nZWalksDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == Id);
            
           // return walkDifficulty;
        }

        public async Task<WalkDifficulty> UpdateWalkDifficulty(WalkDifficulty walkDifficulty, Guid Id)
        {
            var exist_walk = await nZWalksDbContext.WalkDifficulty.FirstOrDefaultAsync(x=>x.Id == Id);
            if(exist_walk == null)
            {
                return null;
            }

            exist_walk.Code = walkDifficulty.Code;

            await nZWalksDbContext.SaveChangesAsync();

            return exist_walk;
        }
    }
}
