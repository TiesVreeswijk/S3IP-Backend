using Business.Entities;

namespace DAL
{
    public interface ITrainingRepository
    {
        void CreateTraining(Training training);
    }
}