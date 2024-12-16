using Business.Dtos.RequestDtos;
using Business.Entities;

namespace Business.Mappers;

public class TrainingSessionMapper
{
    public static TrainingSession TrainingSessionReqToTrainingSession(TrainingSessionReq trainingSessionReq)
    {
        return new TrainingSession
        {
            UserId = trainingSessionReq.UserId,
            TrainingId = trainingSessionReq.TrainingId,
            Date = DateTime.Now
        };
    }
}