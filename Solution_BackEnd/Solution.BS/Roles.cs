using Solution.DAL.EF;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
   public class Roles : ICRUD<data.Roles>
    {
        private SolutionDbContext context;
        public Roles(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.Roles t)
        {
            new DAL.Roles(context).Delete(t);
        }

        public IEnumerable<data.Roles> GetAll()
        {
            return new DAL.Roles(context).GetAll();
        }

        public data.Roles GetOneById(int id)
        {
            return new DAL.Roles(context).GetOneById(id);
        }

        public void Insert(data.Roles t)
        {
            new DAL.Roles(context).Insert(t);
        }

        public void Update(data.Roles t)
        {
            new DAL.Roles(context).Update(t);
        }
    }
}
