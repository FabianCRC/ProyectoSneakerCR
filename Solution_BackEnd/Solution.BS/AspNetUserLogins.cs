using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using data = Solution.DO.Objects;
namespace Solution.BS
{
  public class AspNetUserLogins : ICRUD<data.AspNetUserLogins>
    {
        private SolutionDbContext _repo = null;

        public AspNetUserLogins(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.AspNetUserLogins t)
        {
            new DAL.AspNetUserLogins(_repo).Delete(t);
        }

        public IEnumerable<data.AspNetUserLogins> GetAll()
        {
            return new DAL.AspNetUserLogins(_repo).GetAll();
        }

        public data.AspNetUserLogins GetOneById(int id)
        {
            return new DAL.AspNetUserLogins(_repo).GetOneById(id);
        }

        public void Insert(data.AspNetUserLogins t)
        {
            new DAL.AspNetUserLogins(_repo).Insert(t);
        }

        public void Update(data.AspNetUserLogins t)
        {
            new DAL.AspNetUserLogins(_repo).Update(t);
        }

        public async Task<IEnumerable<data.AspNetUserLogins>> GetAllWithAsync()
        {
            return await new DAL.AspNetUserLogins(_repo).GetAllWithAsync();
        }

        public async Task<data.AspNetUserLogins> GetOneByIdWithAsync(int id)
        {
            return await new DAL.AspNetUserLogins(_repo).GetOneByIdWithAsync(id);
        }
    }
}
