namespace Business.Dtos.RequestDtos;

public class TrainingSessionExerciseReq
{
    public int TrainingSessionId { get; set; }
    public int ExerciseId { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public int Weight { get; set; }
}