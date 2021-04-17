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
    public class AspNetUsers : ICRUD<data.AspNetUsers>
    {
        private SolutionDbContext context;
        public AspNetUsers(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.AspNetUsers t)
        {
            new DAL.AspNetUsers(context).Delete(t);
        }

        public IEnumerable<data.AspNetUsers> GetAll()
        {
            return new DAL.AspNetUsers(context).GetAll();
        }

        public data.AspNetUsers GetOneById(int id)
        {
            return new DAL.AspNetUsers(context).GetOneById(id);
        }


        public void Insert(data.AspNetUsers t)
        {
            new DAL.AspNetUsers(context).Insert(t);
        }

        public void Update(data.AspNetUsers t)
        {
            new DAL.AspNetUsers(context).Update(t);
        }
    }
}
