using TrainComponentManagement.Models;

namespace TrainComponentManagement.Repositories
{
    public interface ITrainComponentQuantityAssignmentRepository
    {
        Task<TrainComponentQuantityAssignment> GetComponentFromTheTableForAssigningQuantity(int id);
        Task AssigningQuantityOfTrainComponent(TrainComponentQuantityAssignment component);
    }
}
