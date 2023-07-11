using TrainComponentManagement.Dtos;
using TrainComponentManagement.Models;

namespace TrainComponentManagement.Repositories
{
    public interface ITrainComponentRepository
    {
        Task<IEnumerable<TrainComponentDto>> GetTrainComponents();
        Task<TrainComponent?> GetTrainComponent(int id);
        Task CreateTrainComponent(TrainComponent trainComponent);
        Task UpdateTrainComponent(TrainComponent trainComponent);
        Task DeleteTrainComponent(int id);
    }
}
