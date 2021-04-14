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
    public class Tiendas : ICRUD<data.Tiendas>
    {
        private Repository<data.Tiendas> _repo = null;
        public Tiendas(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Tiendas>(solutionDbContext);
        }

        public void Delete(data.Tiendas t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Tiendas> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Tiendas GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Tiendas t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Tiendas t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

   
    }
}
