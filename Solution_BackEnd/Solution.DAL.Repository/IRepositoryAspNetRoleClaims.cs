using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryAspNetRoleClaims : IRepository<data.AspNetRoleClaims>
    {
        Task<IEnumerable<data.AspNetRoleClaims>> GetAllWithAsAsync();
        Task<data.AspNetRoleClaims> GetOneByIdWithAsync(int id);
    }
}
