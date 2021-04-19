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
    public class AspNetRoles : ICRUD<data.AspNetRoles>
    {
        private SolutionDbContext context;
        public AspNetRoles(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.AspNetRoles t)
        {
            new DAL.AspNetRoles(context).Delete(t);
        }

        public IEnumerable<data.AspNetRoles> GetAll()
        {
            return new DAL.AspNetRoles(context).GetAll();
        }

        public data.AspNetRoles GetOneById(int id)
        {
            return new DAL.AspNetRoles(context).GetOneById(id);
        }


        public void Insert(data.AspNetRoles t)
        {
            new DAL.AspNetRoles(context).Insert(t);
        }

        public void Update(data.AspNetRoles t)
        {
            new DAL.AspNetRoles(context).Update(t);
        }
    }
}
