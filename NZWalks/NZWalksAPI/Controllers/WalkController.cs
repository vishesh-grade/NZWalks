using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Repository;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walk = await walkRepository.GetAllWalksAsync();

            var walkDTO = mapper.Map<List<Models.DTO.Walk>>(walk);

            return Ok(walkDTO);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        [ActionName("GetWalkbyusingID")]
        public async Task<IActionResult> GetWalkbyusingID(Guid Id)
        {
           
            var walk = await walkRepository.GetWalkByID(Id);

            if(walk == null)
            {
                return BadRequest();
            }

            var walkDTO = mapper.Map<Models.DTO.Walk>(walk);

            return Ok(walkDTO);
        }
        [HttpPost]
        [Route("AddWalk")]
        public async Task<IActionResult> AddWalk([FromBody] Models.DTO.AddWalkRequest addWalkRequest)
        {
            var walk = new Models.Domain.Walk
            {
                
                Name = addWalkRequest.Name,
                Length = addWalkRequest.Length,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkDifficultyId,
                
            };

            await walkRepository.AddWalk(walk);

            var walkDTO = new Models.Domain.Walk
            {
                Id = walk.Id,
                Name = walk.Name,
                Length = walk.Length,
                RegionId = walk.RegionId,
                WalkDifficultyId = walk.WalkDifficultyId
            };
            return CreatedAtAction(nameof(GetWalkbyusingID), new { Id = walkDTO.Id }, walkDTO);
        }
    }
}
