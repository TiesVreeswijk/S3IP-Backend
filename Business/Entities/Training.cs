namespace Business.Entities;

public class Training
{
    public int TrainingId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    
    
    
    public ICollection<TrainingExercise> TrainingExercises { get; set; }
    public ICollection<TrainingSession> TrainingSessions { get; set; }
}