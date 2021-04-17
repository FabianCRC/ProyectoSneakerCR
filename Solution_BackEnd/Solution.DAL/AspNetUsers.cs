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
    public class AspNetUsers : ICRUD<data.AspNetUsers>
    {
        private Repository<data.AspNetUsers> _repo = null;
        public AspNetUsers(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.AspNetUsers>(solutionDbContext);
        }
        public void Delete(data.AspNetUsers t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }


        public IEnumerable<data.AspNetUsers> GetAll()
        {
            return _repo.GetAll();
        }

        public data.AspNetUsers GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

   
        public void Insert(data.AspNetUsers t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.AspNetUsers t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
