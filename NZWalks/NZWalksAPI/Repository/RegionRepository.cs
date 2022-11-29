using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private NZWalksDbContext nZWalksDbContext;

        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await nZWalksDbContext.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region> DeleteAsync(Guid Id)
        {
            var region = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);

            if (region == null)
            {
                return null;
            }
           nZWalksDbContext.Regions.Remove(region);


           await nZWalksDbContext.SaveChangesAsync();

            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return(await nZWalksDbContext.Regions.ToListAsync());
        } 

        public async Task<Region> GetAsync(Guid Id)
        {
          
            return( await nZWalksDbContext.Regions.FirstOrDefaultAsync( x=>x.Id == Id));
        }
    
        }
    }

