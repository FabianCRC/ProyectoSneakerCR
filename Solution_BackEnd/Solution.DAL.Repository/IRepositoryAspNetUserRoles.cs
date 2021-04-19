using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryAspNetUserRoles : IRepository<data.AspNetUserRoles>
    {
        Task<IEnumerable<data.AspNetUserRoles>> GetAllWithAsAsync();
        Task<data.AspNetUserRoles> GetOneByIdWithAsync(int id);
    }
}
