using Business.Dtos.EntityDtos;
using Business.Dtos.RequestDtos;
using Business.Entities;

namespace Business.Interfaces
{
    public interface ITrainingService
    {
        void CreateTraining(TrainingReq trainingReq);
        List<Training> GetTrainingsByUserId(int userId);
        
        void AddExercise(TrainingExerciseReq trainingExerciseReq);
        List<TrainingExerciseDto> getTrainingExercisesById(int id);
        
        void CreateTrainingSession(TrainingSessionReq trainingSessionReq);
    }
}