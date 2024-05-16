using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repository;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

            var regionDTO = mapper.Map<List<Models.DTO.Region>>(regions);
            return ( Ok(regionDTO) );
        }

        [HttpGet]
        [Route("{Id:guid}")]
        [ActionName("GetRegionById")]
        public async Task<IActionResult> GetRegionById(Guid Id)
        {
            var region = await regionRepository.GetAsync(Id);

            if (region == null)
            {
                return BadRequest();
            }
            var regionDTO = mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);

        }
        [HttpPost]

        [Route("AddRegion")]
        public async Task<IActionResult> Add(Models.DTO.AddRegionRequest addRegionRequest)
        {
            var region = new Models.Domain.Region()
            {
                Area = addRegionRequest.Area,
                Long = addRegionRequest.Long,
                Lat = addRegionRequest.Lat,
                Population = addRegionRequest.Population,
                Code = addRegionRequest.Code,
                Name = addRegionRequest.Name
            };


           await regionRepository.AddAsync(region);

            var regionDTO = new Models.Domain.Region
            {
                Id= region.Id,
                Area = region.Area,
                Long = region.Long,
                Lat = region.Lat,
                Population = region.Population,
                Code = region.Code,
                Name = region.Name
            };
            return CreatedAtAction(nameof(GetRegionById),new { Id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var region = await regionRepository.DeleteAsync(Id);

            if (region == null)
            {
                return BadRequest();
            }
            var regionDTO = mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);

        }

        [HttpPut]
        [Route("Update")]

        public async Task<IActionResult> Update(Models.DTO.UpdateRegionRequest updateRegionRequest, Guid Id)
        {
            var region = new Models.Domain.Region()
            {
                Area = updateRegionRequest.Area,
                Long = updateRegionRequest.Long,
                Lat = updateRegionRequest.Lat,
                Population = updateRegionRequest.Population,
                Code = updateRegionRequest.Code,
                Name = updateRegionRequest.Name
            };


            await regionRepository.UpdateAsync(region, Id);

            var regionDTO = new Models.Domain.Region
            {
                Id = region.Id,
                Area = region.Area,
                Long = region.Long,
                Lat = region.Lat,
                Population = region.Population,
                Code = region.Code,
                Name = region.Name
            };
            return Ok(regionDTO);
        }

    }
    }


