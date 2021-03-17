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
    public class RepositoryTelefonoTienda : Repository<data.TelefonoTienda>, IRepositoryTelefonoTienda
    {
        public RepositoryTelefonoTienda(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<data.TelefonoTienda>> GetAllWithAsAsync()
        {
            return await _db.TelefonoTienda
                .Include(m => m.Tiendas)
                .ToListAsync();
        }

        public async Task<data.TelefonoTienda> GetOneByIdWithAsync(int id)
        {
            return await _db.TelefonoTienda
             .Include(m => m.Tiendas)
             .SingleOrDefaultAsync(m => m.IdTelefono == id);
        }



        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
