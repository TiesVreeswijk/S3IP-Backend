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
    }
}