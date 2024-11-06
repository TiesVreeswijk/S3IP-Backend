using Business.Entities;

namespace DAL
{
    public interface ITrainingRepository
    {
        void CreateTraining(Training training);
        List<Training> GetTrainingsByUserId(int userId);
        void AddTrainingExercise(TrainingExercise trainingExercise);
    }
}