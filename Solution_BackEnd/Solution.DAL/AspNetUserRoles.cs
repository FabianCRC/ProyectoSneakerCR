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
    public class AspNetUserRoles : ICRUD<data.AspNetUserRoles>
    {
        private RepositoryAspNetUserRoles _repo = null;

        public AspNetUserRoles(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryAspNetUserRoles(solutionDbContext);
        }

        public void Delete(data.AspNetUserRoles t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.AspNetUserRoles> GetAll()
        {
            return _repo.GetAll();
        }

        public data.AspNetUserRoles GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.AspNetUserRoles t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.AspNetUserRoles t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.AspNetUserRoles>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.AspNetUserRoles> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
