namespace Business.Entities;

public class TrainingExercise
{
    public int TrainingExerciseId { get; set; }
    public int TrainingId { get; set; }
    public int ExerciseId { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    
    public Training Training { get; set; }
}