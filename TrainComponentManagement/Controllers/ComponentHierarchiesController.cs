using Microsoft.AspNetCore.Mvc;
using TrainComponentManagement.Repositories;

namespace TrainComponentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentHierarchiesController : ControllerBase
    {
        private readonly ITrainComponentRepository _trainComponentRepository;
        private readonly IComponentHierarchyRepository _componentHierarchyRepository;

        public ComponentHierarchiesController(ITrainComponentRepository trainComponentRepository,
            IComponentHierarchyRepository componentHierarchyRepository)
        {
            _trainComponentRepository = trainComponentRepository;
            _componentHierarchyRepository = componentHierarchyRepository;
        }

        [HttpGet("hierarchy")]
        public async Task<IActionResult> GetHierarchy()
        {
            var hierarchy = await _componentHierarchyRepository.BuildHierarchy();
            return Ok(hierarchy);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetHierarchyComponentById(int id)
        {
            var hierarchyComponent = await _componentHierarchyRepository.GetTrainComponentClosureById(id);
            return Ok(hierarchyComponent);
        }

        [HttpPost]
        [Route("components/{parentId}/children/{childId}")]
        public async Task<IActionResult> AddChild(int parentId, int childId)
        {
            var parentComponent = await _trainComponentRepository.GetTrainComponent(parentId);
            var childComponent = await _trainComponentRepository.GetTrainComponent(childId);

            if (parentComponent == null || childComponent == null)
                return NotFound();

            if (await _componentHierarchyRepository.IsParentChildRelationExists(parentId, childId))
                return BadRequest("The parent-child relationship already exists.");

            if (parentId == childId)
                return BadRequest("The parent element can't be equel to child element.");

            await _componentHierarchyRepository.AddAsync(parentId, childId);
            return Ok();
        }

        [HttpPut]
        [Route("{elementId}/newparent/{newParentId}")]
        public async Task<IActionResult> UpdateParentChildRelations(int elementId, int newParentId)
        {
            var renewedElement =
                await _componentHierarchyRepository.UpdateParentChildRelationsForElement(elementId, newParentId);

            return Ok(renewedElement);
        }

        [HttpDelete]
        [Route("{elementId}")]
        public async Task RemoveTrainComponentFromHierarchy(int elementId) =>
            await _componentHierarchyRepository.RemoveTrainComponentFromHierarchy(elementId);
    }
}
