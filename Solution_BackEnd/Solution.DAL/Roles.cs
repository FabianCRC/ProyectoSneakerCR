using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Roles : ICRUD<data.Roles>
    {
        private Repository<data.Roles> _repo = null;
        public Roles(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Roles>(solutionDbContext);
        }
        public void Delete(data.Roles t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Roles> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Roles GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Roles t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Roles t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
