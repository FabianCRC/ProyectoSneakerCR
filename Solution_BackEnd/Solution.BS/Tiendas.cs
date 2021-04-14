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
    public class Tiendas : ICRUD<data.Tiendas>
    {
        private SolutionDbContext _repo = null;

        public Tiendas(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.Tiendas t)
        {
            new DAL.Tiendas(_repo).Delete(t);
        }

        public IEnumerable<data.Tiendas> GetAll()
        {
            return new DAL.Tiendas(_repo).GetAll();
        }

        public data.Tiendas GetOneById(int id)
        {
            return new DAL.Tiendas(_repo).GetOneById(id);
        }

        public void Insert(data.Tiendas t)
        {
            new DAL.Tiendas(_repo).Insert(t);
        }

        public void Update(data.Tiendas t)
        {
            new DAL.Tiendas(_repo).Update(t);
        }


    }
}
