using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryAspNetUserClaims : IRepository<data.AspNetUserClaims>
    {
        Task<IEnumerable<data.AspNetUserClaims>> GetAllWithAsAsync();
        Task<data.AspNetUserClaims> GetOneByIdWithAsync(int id);
    }
}
