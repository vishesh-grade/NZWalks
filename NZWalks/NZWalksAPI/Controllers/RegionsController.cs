using AutoMapper;
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
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllAsync();

            /*ar regionDTO = new List<Models.Domain.DTO.Region>();*/

            //regions.ToList().ForEach(region =>
            //{
            //    var regionsDTO = new Models.Domain.DTO.Region()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population
            //    };
            //   regionDTO.Add(regionsDTO);
            //});

            var regionDTO = mapper.Map<List<Models.Domain.DTO.Region>>(regions);
            return ( Ok(regionDTO) );
        }

        [HttpGet]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetRegionById(Guid Id)
        {
            var region = await regionRepository.GetAsync(Id);

            if (region == null)
            {
                return BadRequest();
            }
            var regionDTO = mapper.Map<Models.Domain.DTO.Region>(region);

            return Ok(regionDTO);

        }
               
            
        }
    }


