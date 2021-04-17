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
    public class AspNetUserClaims : ICRUD<data.AspNetUserClaims>
    {
        private RepositoryAspNetUserClaims _repo = null;

        public AspNetUserClaims(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryAspNetUserClaims(solutionDbContext);
        }

        public void Delete(data.AspNetUserClaims t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.AspNetUserClaims> GetAll()
        {
            return _repo.GetAll();
        }

        public data.AspNetUserClaims GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.AspNetUserClaims t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.AspNetUserClaims t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.AspNetUserClaims>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.AspNetUserClaims> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
