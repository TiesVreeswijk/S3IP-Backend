namespace Business.Entities;

public class TrainingSessionExercise
{
    public int TrainingSessionExerciseId { get; set; }
    public int TrainingSessionId { get; set; }
    public int ExerciseId { get; set; }
    public int Weight { get; set; } // Nullable if needed for bodyweight exercises
    public int Sets { get; set; }
    public int Reps { get; set; }

    // Navigation properties
    public TrainingSession TrainingSession { get; set; }
    public Exercise Exercise { get; set; }
}