using Fix_Tune.Models;

namespace Fix_Tune.Logic
{
    public interface IDiscountLogic
    {
        void Create(Discount entity);
        void Delete(int id);
        Discount Read(int id);
        IQueryable<Discount> ReadAll();
        void Update(Discount entity);
    }
}