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
        
        public List<Training> GetTrainingsByUserId(int userId)
        {
            return _context.training.Where(t => t.UserId == userId).ToList();
        }
        
        public void AddTrainingExercise(TrainingExercise trainingExercise)
        {
            _context.TrainingExercise.Add(trainingExercise);
            _context.SaveChanges();
        }
    }
}