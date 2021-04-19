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
    public class RepositoryAspNetRoleClaims : Repository<data.AspNetRoleClaims>, IRepositoryAspNetRoleClaims
    {
        public RepositoryAspNetRoleClaims(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<data.AspNetRoleClaims>> GetAllWithAsAsync()
        {
            return await _db.AspNetRoleClaims
                .Include(m => m.Role)
                .ToListAsync();
        }

        public async Task<data.AspNetRoleClaims> GetOneByIdWithAsync(int id)
        {
            return await _db.AspNetRoleClaims
                .Include(m => m.Role)
             .SingleOrDefaultAsync(m => m.Id == id);
        }



        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}