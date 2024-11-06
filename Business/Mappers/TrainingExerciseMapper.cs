using Business.Dtos.RequestDtos;
using Business.Entities;

namespace Business.Mappers;

public class TrainingExerciseMapper
{
    public static TrainingExercise TrainingExerciseReqToTrainingExercise(TrainingExerciseReq trainingExerciseReq)
    {
        return new TrainingExercise
        {
            TrainingId = trainingExerciseReq.TrainingId,
            ExerciseId = trainingExerciseReq.ExerciseId,
            Sets = trainingExerciseReq.Sets,
            Reps = trainingExerciseReq.Reps
        };
    }
}