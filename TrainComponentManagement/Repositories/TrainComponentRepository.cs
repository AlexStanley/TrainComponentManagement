using Microsoft.EntityFrameworkCore;
using TrainComponentManagement.Dtos;
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

        public async Task<IEnumerable<TrainComponentDto>> GetTrainComponents()
        {
            var trainComponents = await _context.TrainComponents.ToListAsync();

            var trainComponentsAssignedQuantity = await _context.TrainComponentQuantityAssignments.ToListAsync();

            var trainComponentsWithAmounts = trainComponents.GroupJoin(trainComponentsAssignedQuantity,
                tc => tc.ID,
                tcaq => tcaq.TrainComponentID,
                (tc, tcaq) => new TrainComponentDto
                {
                    ID = tc.ID,
                    Name = tc.Name,
                    UniqueNumber = tc.UniqueNumber,
                    CanAssignQuantity = tc.CanAssignQuantity,
                    ItemAmount = tcaq.Select(x => x.Quantity).FirstOrDefault(),
                }).ToList();

            return trainComponentsWithAmounts;
        }

        public async Task<TrainComponent?> GetTrainComponent(int id)
        {
            return await _context.TrainComponents.FindAsync(id);
        }

        public async Task CreateTrainComponent(TrainComponent trainComponent)
        {
            _context.TrainComponents.Add(trainComponent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTrainComponent(TrainComponent trainComponent)
        {
            _context.TrainComponents.Update(trainComponent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrainComponent(int id)
        {
            var trainComponent = await _context.TrainComponents.FindAsync(id);
            _context.TrainComponents.Remove(trainComponent);
            await _context.SaveChangesAsync();
        }
    }
}
