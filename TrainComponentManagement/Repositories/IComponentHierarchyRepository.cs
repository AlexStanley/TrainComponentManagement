using TrainComponentManagement.Dtos;
using TrainComponentManagement.Models;

namespace TrainComponentManagement.Repositories
{
    public interface IComponentHierarchyRepository
    {
        Task<List<TrainComponentDto>> BuildHierarchy();
        Task<ComponentHierarchy?> UpdateParentChildRelationsForElement(int elementId, int newParentid);
        Task RemoveTrainComponentFromHierarchy(int elementId);
        Task<List<ComponentHierarchy>> GetAllAsync();
        Task AddAsync(int parentId, int childId);
        Task<ComponentHierarchy?> GetTrainComponentClosureById(int parentItemID);
        Task<bool> IsParentChildRelationExists(int parentId, int childId);
        Task<bool> HasParent(int trainComponentId);
    }
}
