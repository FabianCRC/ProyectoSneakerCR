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
    public class RepositoryUsuarios : Repository<data.Usuarios>, IRepositoryUsuarios
    {
        public RepositoryUsuarios(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<data.Usuarios>> GetAllWithAsAsync()
        {
            return await _db.Usuarios
                .Include(m => m.IdRol)
                .ToListAsync();
        }

        public async Task<data.Usuarios> GetOneByIdWithAsync(int id)
        {
            return await _db.Usuarios
             .Include(m => m.IdRol)
             .SingleOrDefaultAsync(m => m.IdUsuario == id);
        }



        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
