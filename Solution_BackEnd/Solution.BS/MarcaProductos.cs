using Solution.DAL.EF;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class MarcaProductos : ICRUD<data.MarcaProductos>
    {
        private SolutionDbContext context;
        public MarcaProductos(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.MarcaProductos t)
        {
            new DAL.MarcaProductos(context).Delete(t);
        }

        public IEnumerable<data.MarcaProductos> GetAll()
        {
            return new DAL.MarcaProductos(context).GetAll();
        }

        public data.MarcaProductos GetOneById(int id)
        {
            return new DAL.MarcaProductos(context).GetOneById(id);
        }

        public void Insert(data.MarcaProductos t)
        {
            new DAL.MarcaProductos(context).Insert(t);
        }

        public void Update(data.MarcaProductos t)
        {
            new DAL.MarcaProductos(context).Update(t);
        }
    }
}
