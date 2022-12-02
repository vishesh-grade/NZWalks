using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Repository;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDifficulty()
        {
            var walkDifficulty = await walkDifficultyRepository.GetAllWalkDifficultyAsync();
            var walkDifficultyDTO = mapper.Map<List<Models.DTO.WalkDifficulty>>(walkDifficulty);

            return Ok(walkDifficultyDTO);
        }
        [HttpGet]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetWalkDifficultyBynewID(Guid Id)
        {
            var walkDifficulty = await walkDifficultyRepository.GetWalkDifficultyByID(Id);

            if(walkDifficulty == null)
            {
             return NotFound();
            }
            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

            return Ok(walkDifficulty);
        }
    }
}
