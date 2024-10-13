using Fix_Tune.Models;

namespace Fix_Tune.Logic
{
    public interface ICarIssueLogic
    {
        void Create(CarIssue entity);
        void Delete(int id);
        CarIssue Read(int id);
        IQueryable<CarIssue> ReadAll();
        void Update(CarIssue entity);
    }
}