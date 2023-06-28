using TrainComponentManagement.Models;

namespace TrainComponentManagement.Repositories
{
    public interface IComponentHierarchyRepository
    {
        Task<List<ComponentHierarchy>> GetAllAsync();
        Task AddAsync(ComponentHierarchy componentHierarchy);
        Task<bool> IsParentChildRelationExists(int parentId, int childId);
    }
}
