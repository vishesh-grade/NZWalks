using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.DTO;
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
        [ActionName("GetWalkDifficultyBynewID")]
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

        [HttpPost]
        public async Task<IActionResult> AddWD(AddWalkDifficultyRequest addWalkDifficultyRequest)
        {
            var wD = new Models.Domain.WalkDifficulty
            {
                Id = Guid.NewGuid(),
                Code = addWalkDifficultyRequest.Code
            };

            await walkDifficultyRepository.AddWalkDifficulty(wD);

            var wDDto = new Models.Domain.WalkDifficulty
            { Code = wD.Code };

            return CreatedAtAction(nameof(GetWalkDifficultyBynewID), new { Id = wDDto.Id }, wDDto);


        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWd(Guid Id)
        {
            var wD = await walkDifficultyRepository.DeleteWalkDifficulty(Id);
            if(wD==null)
               return NotFound();
            var wDDto = new Models.Domain.WalkDifficulty
            {
                Id = wD.Id,
                Code = wD.Code
            };

            return Ok(wDDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWalkDifficulty(UpdateWalkDifficultyRequest updateWalkDifficultyRequest, Guid Id)
        {
            var wD = new Models.Domain.WalkDifficulty
            {
                Code = updateWalkDifficultyRequest.Code
            }; 
            await walkDifficultyRepository.UpdateWalkDifficulty(wD, Id);

            var wDDto = new Models.Domain.WalkDifficulty { 
                Id= wD.Id,
                Code = wD.Code };
            return Ok(wDDto);
        }
    }
}
