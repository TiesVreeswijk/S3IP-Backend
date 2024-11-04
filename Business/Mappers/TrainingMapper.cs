using Business.Dtos.RequestDtos;
using Business.Entities;

namespace Business.Mappers
{
    public static class TrainingMapper
    {
        public static Training TrainingDtoToTraining(TrainingReq trainingReq)
        {
            return new Training
            {
                UserId = trainingReq.UserId,
                Name = trainingReq.NewTrainingName,
                
            };
        }
    }
}