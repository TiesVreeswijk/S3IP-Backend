using Business.Entities;
using DAL;

namespace DAL
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly MyDbContext _context;

        public TrainingRepository(MyDbContext context)
        {
            _context = context;
        }

        public void CreateTraining(Training training)
        {
            _context.training.Add(training);
            _context.SaveChanges();
        }
    }
}