using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;
using Microsoft.EntityFrameworkCore;


namespace Solution.DAL.Repository
{
    public class RepositoryProductos : Repository<data.Productos>, IRepositoryProductos
    {
        public RepositoryProductos(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<data.Productos>> GetAllWithAsAsync()
        {
            return await _db.Productos
                .Include(m => m.MarcaProductos)
                .Include(m => m.Tiendas)
                .Include(m => m.CategoriaProductos)
                .ToListAsync();
        }

        public async Task<data.Productos> GetOneByIdWithAsync(int id)
        {
            return await _db.Productos
                .Include(m => m.MarcaProductos)
                .Include(m => m.Tiendas)
                .Include(m => m.CategoriaProductos)
             .SingleOrDefaultAsync(m => m.IdProducto == id);
        }



        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
