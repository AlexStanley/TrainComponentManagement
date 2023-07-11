using Microsoft.EntityFrameworkCore;
using TrainComponentManagement.Dtos;
using TrainComponentManagement.Models;

namespace TrainComponentManagement.Repositories
{
    public class ComponentHierarchyRepository : IComponentHierarchyRepository
    {
        private readonly TrainComponentContext _context;
        private readonly ITrainComponentRepository _trainComponentRepository;
        public ComponentHierarchyRepository(TrainComponentContext context,
            ITrainComponentRepository trainComponentRepository)
        {
            _context = context;
            _trainComponentRepository = trainComponentRepository;
        }

        public async Task<List<TrainComponentDto>> BuildHierarchy()
        {
            List<TrainComponentDto> rootComponent = new();

            var components = await TrainComponentDtoFormationAsync();

            foreach (var component in components)
            {
                if (component.ParentComponentID == 0)
                {
                    rootComponent.Add(component);
                    await BuildChildHierarchy(components, component);
                }
            }

            return rootComponent;
        }

        public async Task<ComponentHierarchy?> UpdateParentChildRelationsForElement(int elementId, int newParentId)
        {
            var trainComponentClosure = await GetTrainComponentClosureById(elementId);

            _context.ComponentHierarchies.Remove(trainComponentClosure);
            await _context.SaveChangesAsync();

            await AddAsync(newParentId, elementId);

            return await GetTrainComponentClosureById(elementId);
        }

        public async Task RemoveTrainComponentFromHierarchy(int elementId)
        {
            var trainComponentClosure = await GetTrainComponentClosureById(elementId);

            _context.ComponentHierarchies.Remove(trainComponentClosure);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ComponentHierarchy>> GetAllAsync()
        {
            return await _context.ComponentHierarchies.OrderBy(comp => comp.Depth).ToListAsync();
        }

        public async Task AddAsync(int parentId, int childId)
        {
            var parentComponent = await _trainComponentRepository.GetTrainComponent(parentId);
            var childComponent = await _trainComponentRepository.GetTrainComponent(childId);

            var parentItemInHierarchy = await GetTrainComponentClosureById(parentId);

            var componentHierarchy = new ComponentHierarchy
            {
                ParentComponentID = parentId,
                ParentComponent = parentComponent,
                ChildComponentID = childId,
                ChildComponent = childComponent,
                Depth = parentItemInHierarchy == null ? 1 : parentItemInHierarchy.Depth + 1
            };

            _context.ComponentHierarchies.Add(componentHierarchy);
            await _context.SaveChangesAsync();
        }

        public async Task<ComponentHierarchy?> GetTrainComponentClosureById(int parentItemID)
        {
            return await _context.ComponentHierarchies.SingleOrDefaultAsync(ch => ch.ChildComponentID == parentItemID);
        }

        public async Task<bool> IsParentChildRelationExists(int parentId, int childId)
        {
            return await _context.ComponentHierarchies
                .AnyAsync(ch => ch.ParentComponentID == parentId && ch.ChildComponentID == childId);
        }

        public async Task<bool> HasParent(int trainComponentId)
        {
            return await _context.ComponentHierarchies.AnyAsync(ch => ch.ChildComponentID == trainComponentId);
        }

        private async Task<List<ComponentHierarchy>> CreateFullListOfRelationsBetweenComponents()
        {
            var components = await GetAllAsync();
            var trainComponents = await _context.TrainComponents.ToListAsync();

            foreach (var item in trainComponents)
            {
                if (!components.Where(c => c.ChildComponentID == item.ID).Any())
                    components.Insert(0, new ComponentHierarchy
                    {
                        ParentComponentID = 0,
                        ParentComponent = null,
                        ChildComponentID = item.ID,
                        Depth = 0
                    });
            }

            return components;
        }

        private async Task<List<TrainComponentDto>> TrainComponentDtoFormationAsync()
        {
            var trainComponentsClosure = await CreateFullListOfRelationsBetweenComponents();
            var trainComponents = await _trainComponentRepository.GetTrainComponents();

            var components = trainComponentsClosure.Join(trainComponents,
                tcc => tcc.ChildComponentID,
                tc => tc.ID,
                (tcc, tc) => new TrainComponentDto
                {
                    ID = tc.ID,
                    Name = tc.Name,
                    UniqueNumber = tc.UniqueNumber,
                    CanAssignQuantity = tc.CanAssignQuantity,
                    ParentComponentID = tcc.ParentComponentID,
                    Children = new List<TrainComponentDto>()
                }).ToList();

            return components;
        }

        private async Task BuildChildHierarchy(List<TrainComponentDto> components,
            TrainComponentDto parentElement)
        {
            foreach (var component in components)
            {
                if (component.ParentComponentID == parentElement.ID)
                {
                    parentElement.Children.Add(component);
                    await BuildChildHierarchy(components, component);
                }
            }
        }
    }
}
