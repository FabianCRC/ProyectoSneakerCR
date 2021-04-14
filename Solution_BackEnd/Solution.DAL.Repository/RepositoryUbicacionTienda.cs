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
    public class RepositoryUbicacionTienda : Repository<data.UbicacionTienda>, IRepositoryUbicacionTienda
    {
        public RepositoryUbicacionTienda(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<data.UbicacionTienda>> GetAllWithAsAsync()
        {
            return await _db.UbicacionTienda
                .Include(m => m.Tiendas)
                .ToListAsync();
        }

        public async Task<data.UbicacionTienda> GetOneByIdWithAsync(int id)
        {
            return await _db.UbicacionTienda
                .Include(m => m.Tiendas)
             .SingleOrDefaultAsync(m => m.IdUbicacion == id);
        }



        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
