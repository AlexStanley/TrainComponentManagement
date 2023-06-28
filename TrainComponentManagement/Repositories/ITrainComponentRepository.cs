using TrainComponentManagement.Models;

namespace TrainComponentManagement.Repositories
{
    public interface ITrainComponentRepository
    {
        Task<List<TrainComponent>> GetAllAsync();
        Task<TrainComponent?> GetByIdAsync(int id);
        Task AddAsync(TrainComponent trainComponent);
        Task UpdateAsync(TrainComponent trainComponent);
        Task DeleteAsync(int id);
    }
}
