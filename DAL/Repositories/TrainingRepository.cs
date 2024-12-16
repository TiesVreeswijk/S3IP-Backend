using Business.Dtos.EntityDtos;
using Business.Entities;
using DAL;
using Microsoft.EntityFrameworkCore;

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
        
        public List<TrainingExerciseDto> getTrainingExercisesById(int id)
        {
            var exercises = _context.TrainingExercise
                .Where(te => te.TrainingId == id)
                .Include(te => te.Exercise)
                .Select(te => new TrainingExerciseDto
                {
                    Name = te.Exercise.Name,
                    Sets = te.Sets,
                    Reps = te.Reps,
                    ImageUrl = te.Exercise.ImageUrl
                })
                .ToList();

            return exercises;
        }

        public void CreateTrainingSession(TrainingSession trainingSession)
        {
            _context.TrainingSession.Add(trainingSession);
            _context.SaveChanges();
        }
    }
}