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
   public class AspNetUserClaims : ICRUD<data.AspNetUserClaims>
    {
        private SolutionDbContext _repo = null;

        public AspNetUserClaims(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.AspNetUserClaims t)
        {
            new DAL.AspNetUserClaims(_repo).Delete(t);
        }

        public IEnumerable<data.AspNetUserClaims> GetAll()
        {
            return new DAL.AspNetUserClaims(_repo).GetAll();
        }

        public data.AspNetUserClaims GetOneById(int id)
        {
            return new DAL.AspNetUserClaims(_repo).GetOneById(id);
        }

        public void Insert(data.AspNetUserClaims t)
        {
            new DAL.AspNetUserClaims(_repo).Insert(t);
        }

        public void Update(data.AspNetUserClaims t)
        {
            new DAL.AspNetUserClaims(_repo).Update(t);
        }

        public async Task<IEnumerable<data.AspNetUserClaims>> GetAllWithAsync()
        {
            return await new DAL.AspNetUserClaims(_repo).GetAllWithAsync();
        }

        public async Task<data.AspNetUserClaims> GetOneByIdWithAsync(int id)
        {
            return await new DAL.AspNetUserClaims(_repo).GetOneByIdWithAsync(id);
        }
    }
}
