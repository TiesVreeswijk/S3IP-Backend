namespace Business.Entities;

public class TrainingSession
{
    public int TrainingSessionId { get; set; }
    public int TrainingId { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }

    // Navigation properties
    public Training Training { get; set; }
    public User User { get; set; }
    public ICollection<TrainingSessionExercise> TrainingSessionExercises { get; set; }
}