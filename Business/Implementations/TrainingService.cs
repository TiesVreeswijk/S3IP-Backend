using Business.Dtos.RequestDtos;
using Business.Entities;
using Business.Interfaces;
using Business.Mappers;
using DAL;

namespace Business
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;

        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public void CreateTraining(TrainingReq trainingReq)
        {
            var newTraining = TrainingMapper.TrainingDtoToTraining(trainingReq);
            _trainingRepository.CreateTraining(newTraining);
        }
        
        public List<Training> GetTrainingsByUserId(int userId)
        {
            List<Training> trainings = _trainingRepository.GetTrainingsByUserId(userId);
            return trainings;
        }
        
        public void AddExercise(TrainingExerciseReq trainingExerciseReq)
        {
            
            var newTrainingExercise = TrainingExerciseMapper.TrainingExerciseReqToTrainingExercise(trainingExerciseReq);
            _trainingRepository.AddTrainingExercise(newTrainingExercise);
        }
    }
}