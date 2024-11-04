namespace Business.Dtos.RequestDtos;

public class TrainingReq
{
    public int UserId { get; set; }
    public string NewTrainingName { get; set; }
    public DateTime TimeCompleted { get; set; }
}