namespace Business.Dtos.RequestDtos;

public class TrainingExerciseReq
{
    public int TrainingId { get; set; }
    public int ExerciseId { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
}