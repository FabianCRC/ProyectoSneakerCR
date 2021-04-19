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
    public class AspNetRoleClaims : ICRUD<data.AspNetRoleClaims>
    {
        private SolutionDbContext _repo = null;

        public AspNetRoleClaims(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.AspNetRoleClaims t)
        {
            new DAL.AspNetRoleClaims(_repo).Delete(t);
        }

        public IEnumerable<data.AspNetRoleClaims> GetAll()
        {
            return new DAL.AspNetRoleClaims(_repo).GetAll();
        }

        public data.AspNetRoleClaims GetOneById(int id)
        {
            return new DAL.AspNetRoleClaims(_repo).GetOneById(id);
        }

        public void Insert(data.AspNetRoleClaims t)
        {
            new DAL.AspNetRoleClaims(_repo).Insert(t);
        }

        public void Update(data.AspNetRoleClaims t)
        {
            new DAL.AspNetRoleClaims(_repo).Update(t);
        }

        public async Task<IEnumerable<data.AspNetRoleClaims>> GetAllWithAsync()
        {
            return await new DAL.AspNetRoleClaims(_repo).GetAllWithAsync();
        }

        public async Task<data.AspNetRoleClaims> GetOneByIdWithAsync(int id)
        {
            return await new DAL.AspNetRoleClaims(_repo).GetOneByIdWithAsync(id);
        }
    }
}
