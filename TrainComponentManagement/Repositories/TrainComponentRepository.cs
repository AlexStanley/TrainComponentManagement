using Microsoft.EntityFrameworkCore;
using TrainComponentManagement.Models;

namespace TrainComponentManagement.Repositories
{
    public class TrainComponentRepository : ITrainComponentRepository
    {
        private readonly TrainComponentContext _context;
        public TrainComponentRepository(TrainComponentContext context)
        {
            _context = context;
        }

        public async Task<List<TrainComponent>> GetAllAsync()
        {
            return await _context.TrainComponents.ToListAsync();
        }

        public async Task<TrainComponent?> GetByIdAsync(int id)
        {
            return await _context.TrainComponents.FindAsync(id);
        }

        public async Task AddAsync(TrainComponent trainComponent)
        {
            _context.TrainComponents.Add(trainComponent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TrainComponent trainComponent)
        {
            _context.Entry(trainComponent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var trainComponent = await _context.TrainComponents.FindAsync(id);
            _context.TrainComponents.Remove(trainComponent);
            await _context.SaveChangesAsync();
        }
    }
}
