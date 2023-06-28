using Microsoft.AspNetCore.Mvc;
using TrainComponentManagement.Models;
using TrainComponentManagement.Repositories;

namespace TrainComponentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainComponentsController : ControllerBase
    {
        private readonly ITrainComponentRepository _trainComponentRepository;

        public TrainComponentsController(ITrainComponentRepository trainComponentRepository)
        {
            _trainComponentRepository = trainComponentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainComponents = await _trainComponentRepository.GetAllAsync();
            return Ok(trainComponents);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var trainComponent = await _trainComponentRepository.GetByIdAsync(id);

            if (trainComponent == null)
                return NotFound();

            return Ok(trainComponent);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrainComponent trainComponent)
        {
            await _trainComponentRepository.AddAsync(trainComponent);
            return Ok(trainComponent);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, TrainComponent trainComponent)
        {
            if (id != trainComponent.ID)
                return BadRequest();

            await _trainComponentRepository.UpdateAsync(trainComponent);
            return Ok(trainComponent);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _trainComponentRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
