using Fix_Tune.Models;

namespace Fix_Tune.Logic
{
    public interface IWorkshopLogic
    {
        void Create(Workshop entity);
        void Delete(int id);
        Workshop Read(int id);
        IQueryable<Workshop> ReadAll();
        void Update(Workshop entity);
    }
}