using Fix_Tune.Models;

namespace Fix_Tune.Logic
{
    internal interface IDiscountLogic
    {
        void Create(Discount entity);
        void Delete(int id);
        Discount Read(int id);
        IQueryable<Discount> ReadAll();
        void Update(Discount entity);
    }
}