using Microsoft.EntityFrameworkCore;
using TrainComponentManagement.Models;

namespace TrainComponentManagement.Repositories
{
    public class TrainComponentQuantityAssignmentRepository : ITrainComponentQuantityAssignmentRepository
    {
        private readonly TrainComponentContext _context;
        private readonly ITrainComponentRepository _trainComponentRepository;

        public TrainComponentQuantityAssignmentRepository(TrainComponentContext context,
            ITrainComponentRepository trainComponentRepository)
        {
            _context = context;
            _trainComponentRepository = trainComponentRepository;
        }

        public async Task<TrainComponentQuantityAssignment> GetComponentFromTheTableForAssigningQuantity(int id)
        {
            var temp = await _context.TrainComponentQuantityAssignments.FirstOrDefaultAsync(comp => comp.TrainComponentID == id)
                ?? new TrainComponentQuantityAssignment { TrainComponentID = id };

            return temp;
        }

        public async Task AssigningQuantityOfTrainComponent(TrainComponentQuantityAssignment component)
        {
            var quantityComponent = await _context.TrainComponentQuantityAssignments
                .FirstOrDefaultAsync(comp => comp.TrainComponentID == component.TrainComponentID);

            var trainComponent = await _trainComponentRepository.GetTrainComponent(component.TrainComponentID);
            component.TrainComponent = trainComponent;

            if (quantityComponent is null)
                _context.TrainComponentQuantityAssignments.Add(component);
            else
            {
                _context.Entry(quantityComponent).State = EntityState.Detached;
                _context.TrainComponentQuantityAssignments.Update(component);
            }


            await _context.SaveChangesAsync();
        }
    }
}
