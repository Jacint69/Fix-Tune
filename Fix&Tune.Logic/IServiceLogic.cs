using Fix_Tune.Models;

namespace Fix_Tune.Logic
{
    public interface IServiceLogic
    {
        void Create(Service entity);
        void Delete(int id);
        Service Read(int id);
        IQueryable<Service> ReadAll();
        void Update(Service entity);
    }
}