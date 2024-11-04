using Business.Dtos.RequestDtos;

namespace Business.Interfaces
{
    public interface ITrainingService
    {
        void CreateTraining(TrainingReq trainingReq);
    }
}