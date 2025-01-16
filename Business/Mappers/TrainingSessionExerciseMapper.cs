using Business.Dtos.RequestDtos;
using Business.Entities;

namespace Business.Mappers;

public class TrainingSessionExerciseMapper
{
    public static TrainingSessionExercise TrainingSessionExerciseReqToTrainingSessionExercise(TrainingSessionExerciseReq trainingSessionExerciseReq)
    {
        return new TrainingSessionExercise
        {
            TrainingSessionId = trainingSessionExerciseReq.TrainingSessionId,
            ExerciseId = trainingSessionExerciseReq.ExerciseId,
            Sets = trainingSessionExerciseReq.Sets,
            Reps = trainingSessionExerciseReq.Reps,
            Weight = trainingSessionExerciseReq.Weight
        };
    }
}