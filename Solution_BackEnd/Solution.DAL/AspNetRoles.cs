using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;
namespace Solution.DAL
{
    public class AspNetRoles : ICRUD<data.AspNetRoles>
    {
        private Repository<data.AspNetRoles> _repo = null;
        public AspNetRoles(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.AspNetRoles>(solutionDbContext);
        }
        public void Delete(data.AspNetRoles t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }


        public IEnumerable<data.AspNetRoles> GetAll()
        {
            return _repo.GetAll();
        }

        public data.AspNetRoles GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

   
        public void Insert(data.AspNetRoles t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.AspNetRoles t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
