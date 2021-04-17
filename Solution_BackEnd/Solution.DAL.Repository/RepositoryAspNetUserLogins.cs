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
    public class RepositoryAspNetUserLogins : Repository<data.AspNetUserLogins>, IRepositoryAspNetUserLogins
    {
        public RepositoryAspNetUserLogins(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<data.AspNetUserLogins>> GetAllWithAsAsync()
        {
            return await _db.AspNetUserLogins
                .Include(m => m.User)
                .ToListAsync();
        }

        public async Task<data.AspNetUserLogins> GetOneByIdWithAsync(int id)
        {
            return await _db.AspNetUserLogins
                .Include(m => m.User)
             .SingleOrDefaultAsync(m => m.UserId.Equals(id));
        }



        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
