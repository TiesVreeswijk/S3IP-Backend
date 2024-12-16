using Business.Dtos.EntityDtos;
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
        
        public List<TrainingExerciseDto> getTrainingExercisesById(int id)
        {
            List<TrainingExerciseDto> exercises = _trainingRepository.getTrainingExercisesById(id);
            return exercises;
        }
        
        public void CreateTrainingSession(TrainingSessionReq trainingSessionReq)
        {
            var newTrainingSession = TrainingSessionMapper.TrainingSessionReqToTrainingSession(trainingSessionReq);
            _trainingRepository.CreateTrainingSession(newTrainingSession);
        }
    }
}