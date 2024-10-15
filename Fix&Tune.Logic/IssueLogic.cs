using Fix_Tune.Models;
using Fix_Tune.Repository;

namespace Fix_Tune.Logic
{
    public class IssueLogic : IIssueLogic
    {
        IRepository<Issue> repo;
        public IssueLogic(IRepository<Issue> repo)
        {
            this.repo = repo;
        }

        public void Create(Issue entity)
        {
            repo.Create(entity);
        }

        public void Update(Issue entity)
        {
            repo.Update(entity);
        }

        public Issue Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Issue> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}
