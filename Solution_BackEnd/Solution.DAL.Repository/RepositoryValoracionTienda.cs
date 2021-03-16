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
    public class RepositoryValoracionTienda : Repository<data.ValoracionTienda>, IRepositoryValoracionTienda
    {
        public RepositoryValoracionTienda(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<data.ValoracionTienda>> GetAllWithAsAsync()
        {
            return await _db.ValoracionTienda
                .Include(m => m.IdUsuario)
                .Include(m => m.IdTienda)
                .ToListAsync();
        }

        public async Task<data.ValoracionTienda> GetOneByIdWithAsync(int id)
        {
            return await _db.ValoracionTienda
              .Include(m => m.IdUsuario)
                .Include(m => m.IdTienda)
             .SingleOrDefaultAsync(m => m.IdTienda == id);
        }



        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}