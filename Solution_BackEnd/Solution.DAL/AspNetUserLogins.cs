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
    public class AspNetUserLogins : ICRUD<data.AspNetUserLogins>
    {
        private RepositoryAspNetUserLogins _repo = null;

        public AspNetUserLogins(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryAspNetUserLogins(solutionDbContext);
        }

        public void Delete(data.AspNetUserLogins t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.AspNetUserLogins> GetAll()
        {
            return _repo.GetAll();
        }

        public data.AspNetUserLogins GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.AspNetUserLogins t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.AspNetUserLogins t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.AspNetUserLogins>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.AspNetUserLogins> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
