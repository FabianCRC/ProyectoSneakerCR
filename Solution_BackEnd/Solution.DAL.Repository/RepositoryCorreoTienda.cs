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
    public class RepositoryCorreoTienda : Repository<data.CorreoTienda>, IRepositoryCorreoTienda
    {
        public RepositoryCorreoTienda(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<data.CorreoTienda>> GetAllWithAsAsync()
        {
            return await _db.CorreoTienda
                .Include(m => m.Tiendas)
                .ToListAsync();
        }

        public async Task<data.CorreoTienda> GetOneByIdWithAsync(int id)
        {
            return await _db.CorreoTienda
                .Include(m => m.Tiendas)
             .SingleOrDefaultAsync(m => m.IdCorreo == id);
        }



        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
