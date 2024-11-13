using Fix_Tune.Models;

namespace Fix_Tune.Logic
{
    public interface ITuningPartLogic
    {
        void Create(TuningPart entity);
        void Delete(int id);
        TuningPart Read(int id);
        IQueryable<TuningPart> ReadAll();
        void Update(TuningPart entity);
    }
}