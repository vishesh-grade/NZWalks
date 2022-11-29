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

        public async Task<Region> UpdateAsync(Region region, Guid Id)
        {
           var exist_region = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (exist_region == null)
            {
                return null;
            }

            exist_region.Code = region.Code;
            exist_region.Lat = region.Lat;
            exist_region.Area = region.Area;               
            exist_region.Long = region.Long;
            exist_region.Population = region.Population;
            exist_region.Name = region.Name;
            await nZWalksDbContext.SaveChangesAsync();
            return(exist_region);

        }
    }
    }

