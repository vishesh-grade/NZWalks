using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Repository;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllAsync();

            var regionDTO = new List<Models.Domain.DTO.Region>();
            regions.ToList().ForEach(region =>
            {
                var regionsDTO = new Models.Domain.DTO.Region()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    Area = region.Area,
                    Lat = region.Lat,
                    Long = region.Long,
                    Population = region.Population
                };
               regionDTO.Add(regionsDTO);
            });
            return ( Ok(regionDTO) );
        }
    }
}

