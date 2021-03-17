using Solution.DAL.EF;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
   public class CategoriaProductos : ICRUD<data.CategoriaProductos>
    {
        private SolutionDbContext context;
        public CategoriaProductos(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.CategoriaProductos t)
        {
            new DAL.CategoriaProductos(context).Delete(t);
        }

        public IEnumerable<data.CategoriaProductos> GetAll()
        {
            return new DAL.CategoriaProductos(context).GetAll();
        }

        public data.CategoriaProductos GetOneById(int id)
        {
            return new DAL.CategoriaProductos(context).GetOneById(id);
        }

        public void Insert(data.CategoriaProductos t)
        {
            new DAL.CategoriaProductos(context).Insert(t);
        }


        public void Update(data.CategoriaProductos t)
        {
            new DAL.CategoriaProductos(context).Update(t);
        }

        IEnumerable<data.CategoriaProductos> ICRUD<data.CategoriaProductos>.GetAll()
        {
            throw new NotImplementedException();
        }

        data.CategoriaProductos ICRUD<data.CategoriaProductos>.GetOneById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
