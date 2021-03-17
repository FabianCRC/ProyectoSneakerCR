using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class MarcaProductos : ICRUD<data.MarcaProductos>
    {
        private Repository<data.MarcaProductos> _repo = null;
        public MarcaProductos(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.MarcaProductos>(solutionDbContext);
        }
        public void Delete(data.MarcaProductos t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.MarcaProductos> GetAll()
        {
            return _repo.GetAll();
        }

        public data.MarcaProductos GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.MarcaProductos t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.MarcaProductos t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
