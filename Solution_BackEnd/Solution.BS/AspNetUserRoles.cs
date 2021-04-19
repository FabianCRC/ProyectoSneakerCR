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
    public class AspNetUserRoles : ICRUD<data.AspNetUserRoles>
    {
        private SolutionDbContext _repo = null;

        public AspNetUserRoles(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.AspNetUserRoles t)
        {
            new DAL.AspNetUserRoles(_repo).Delete(t);
        }

        public IEnumerable<data.AspNetUserRoles> GetAll()
        {
            return new DAL.AspNetUserRoles(_repo).GetAll();
        }

        public data.AspNetUserRoles GetOneById(int id)
        {
            return new DAL.AspNetUserRoles(_repo).GetOneById(id);
        }

        public void Insert(data.AspNetUserRoles t)
        {
            new DAL.AspNetUserRoles(_repo).Insert(t);
        }

        public void Update(data.AspNetUserRoles t)
        {
            new DAL.AspNetUserRoles(_repo).Update(t);
        }

        public async Task<IEnumerable<data.AspNetUserRoles>> GetAllWithAsync()
        {
            return await new DAL.AspNetUserRoles(_repo).GetAllWithAsync();
        }

        public async Task<data.AspNetUserRoles> GetOneByIdWithAsync(int id)
        {
            return await new DAL.AspNetUserRoles(_repo).GetOneByIdWithAsync(id);
        }
    }
}
