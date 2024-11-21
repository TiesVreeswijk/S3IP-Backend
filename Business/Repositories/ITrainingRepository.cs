using Business.Dtos.EntityDtos;
using Business.Entities;

namespace DAL
{
    public interface ITrainingRepository
    {
        void CreateTraining(Training training);
        List<Training> GetTrainingsByUserId(int userId);
        void AddTrainingExercise(TrainingExercise trainingExercise);
        List<TrainingExerciseDto> getTrainingExercisesById(int id);
    }
}