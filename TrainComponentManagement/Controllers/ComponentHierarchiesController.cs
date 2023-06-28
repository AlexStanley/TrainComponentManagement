using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainComponentManagement.Dtos;
using TrainComponentManagement.Models;
using TrainComponentManagement.Repositories;

namespace TrainComponentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentHierarchiesController : ControllerBase
    {
        private readonly ITrainComponentRepository _trainComponentRepository;
        private readonly IComponentHierarchyRepository _componentHierarchyRepository;
        private readonly IMapper _mapper;
        public ComponentHierarchiesController(ITrainComponentRepository trainComponentRepository,
            IComponentHierarchyRepository componentHierarchyRepository, IMapper mapper)
        {
            _trainComponentRepository = trainComponentRepository;
            _componentHierarchyRepository = componentHierarchyRepository;
            _mapper = mapper;
        }

        [HttpGet("hierarchy")]
        public async Task<IActionResult> GetHierarchy()
        {
            var trainComponents = await _trainComponentRepository.GetAllAsync();
            var componentHierarchies = await _componentHierarchyRepository.GetAllAsync();

            var rootComponents = new List<TrainComponentDto>();

            foreach (var component in trainComponents)
            {
                if (!componentHierarchies.Any(ch => ch.ChildComponentID == component.ID))
                {
                    var rootComponent = _mapper.Map<TrainComponentDto>(component);
                    BuildHierarchy(component, componentHierarchies, rootComponent);
                    rootComponents.Add(rootComponent);
                }
            }

            return Ok(rootComponents);
        }

        [HttpPost]
        [Route("components/{parentId}/children")]
        public async Task<IActionResult> AddChild(int parentId, [FromBody] int childId)
        {
            var parentComponent = await _trainComponentRepository.GetByIdAsync(parentId);
            var childComponent = await _trainComponentRepository.GetByIdAsync(childId);

            if (parentComponent == null || childComponent == null)
                return NotFound();

            // Check if the parent-child relationship already exists
            if (await _componentHierarchyRepository.IsParentChildRelationExists(parentId, childId))
                return BadRequest("The parent-child relationship already exists.");

            var componentHierarchy = new ComponentHierarchy
            {
                ParentComponentID = parentId,
                ChildComponentID = childId
            };

            await _componentHierarchyRepository.AddAsync(componentHierarchy);
            return Ok();
        }

        [HttpPut("components/{id}/assignquantity")]
        public async Task<IActionResult> AssignQuantity(int id, [FromBody] bool canAssignQuantity)
        {
            var trainComponent = await _trainComponentRepository.GetByIdAsync(id);

            if (trainComponent == null)
                return NotFound();

            trainComponent.CanAssignQuantity = canAssignQuantity;
            await _trainComponentRepository.UpdateAsync(trainComponent);

            return Ok();
        }

        private void BuildHierarchy(TrainComponent parentComponent, List<ComponentHierarchy> hierarchies, 
            TrainComponentDto dto)
        {
            var children = hierarchies
                .Where(ch => ch.ParentComponentID == parentComponent.ID)
                .Select(ch => _mapper.Map<TrainComponentDto>(ch.ChildComponent))
                .ToList();

            foreach (var child in children)
                BuildHierarchy(_mapper.Map<TrainComponent>(child), hierarchies, child);

            dto.Children = children;
        }
    }
}
