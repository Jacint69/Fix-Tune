using Fix_Tune.Models;

namespace Fix_Tune.Logic
{
    public interface IIssueLogic
    {
        void Create(Issue entity);
        Issue Read(int id);
        IQueryable<Issue> ReadAll();
        void Update(Issue entity);
    }
}