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
    public class RepositoryAspNetUserClaims : Repository<data.AspNetUserClaims>, IRepositoryAspNetUserClaims
    {
        public RepositoryAspNetUserClaims(SolutionDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<data.AspNetUserClaims>> GetAllWithAsAsync()
        {
            return await _db.AspNetUserClaims
                .Include(m => m.User)
                .ToListAsync();
        }

        public async Task<data.AspNetUserClaims> GetOneByIdWithAsync(int id)
        {
            return await _db.AspNetUserClaims
                .Include(m => m.User)
             .SingleOrDefaultAsync(m => m.UserId.Equals(id));
        }



        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
