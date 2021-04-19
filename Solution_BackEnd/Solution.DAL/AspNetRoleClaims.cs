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
    public class AspNetRoleClaims : ICRUD<data.AspNetRoleClaims>
    {
        private RepositoryAspNetRoleClaims _repo = null;

        public AspNetRoleClaims(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryAspNetRoleClaims(solutionDbContext);
        }

        public void Delete(data.AspNetRoleClaims t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.AspNetRoleClaims> GetAll()
        {
            return _repo.GetAll();
        }

        public data.AspNetRoleClaims GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.AspNetRoleClaims t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.AspNetRoleClaims t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.AspNetRoleClaims>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.AspNetRoleClaims> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
