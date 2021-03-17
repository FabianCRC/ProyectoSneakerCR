using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class CategoriaProductos : ICRUD<data.CategoriaProductos>
    {
        private Repository<data.CategoriaProductos> _repo = null;
        public CategoriaProductos(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.CategoriaProductos>(solutionDbContext);
        }
        public void Delete(data.CategoriaProductos t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.CategoriaProductos> GetAll()
        {
            return _repo.GetAll();
        }

        public data.CategoriaProductos GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.CategoriaProductos t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.CategoriaProductos t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
