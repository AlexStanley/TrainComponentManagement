using Microsoft.AspNetCore.Mvc;
using TrainComponentManagement.Models;
using TrainComponentManagement.Repositories;

namespace TrainComponentManagement.Controllers
{
    [Route("api/train-component-quantity-assignments")]
    [ApiController]
    public class TrainComponentQuantityAssignmentsController : ControllerBase
    {
        private readonly ITrainComponentQuantityAssignmentRepository _trainComponentQuantityAssignmentRepository;

        public TrainComponentQuantityAssignmentsController(ITrainComponentQuantityAssignmentRepository trainComponentQuantityAssignmentRepository)
        {
            _trainComponentQuantityAssignmentRepository = trainComponentQuantityAssignmentRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetElementById(int id)
        {
            var element = await _trainComponentQuantityAssignmentRepository
                .GetComponentFromTheTableForAssigningQuantity(id);

            return Ok(element);
        }

        [HttpPost]
        public async Task<IActionResult> AssignQuantity(TrainComponentQuantityAssignment assignment)
        {
            await _trainComponentQuantityAssignmentRepository.AssigningQuantityOfTrainComponent(assignment);
            return Ok();
        }
    }
}
