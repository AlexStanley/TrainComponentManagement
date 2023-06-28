using Microsoft.EntityFrameworkCore;
using TrainComponentManagement.Models;

namespace TrainComponentManagement.Repositories
{
    public class ComponentHierarchyRepository : IComponentHierarchyRepository
    {
        private readonly TrainComponentContext _context;
        public ComponentHierarchyRepository(TrainComponentContext context)
        {
            _context = context;
        }

        public async Task<List<ComponentHierarchy>> GetAllAsync()
        {
            return await _context.ComponentHierarchies.ToListAsync();
        }

        public async Task AddAsync(ComponentHierarchy componentHierarchy)
        {
            _context.ComponentHierarchies.Add(componentHierarchy);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsParentChildRelationExists(int parentId, int childId)
        {
            return await _context.ComponentHierarchies
                .AnyAsync(ch => ch.ParentComponentID == parentId && ch.ChildComponentID == childId);
        }
    }
}
