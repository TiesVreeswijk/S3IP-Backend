namespace Business.Dtos.EntityDtos;

public class TrainingExerciseDto
{
    public string Name { get; set; } = string.Empty;
    public int Sets { get; set; }
    public int Reps { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}