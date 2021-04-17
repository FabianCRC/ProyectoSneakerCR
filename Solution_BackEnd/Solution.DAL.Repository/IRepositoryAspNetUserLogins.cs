using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;
namespace Solution.DAL.Repository
{
    public interface IRepositoryAspNetUserLogins : IRepository<data.AspNetUserLogins>
    {
        Task<IEnumerable<data.AspNetUserLogins>> GetAllWithAsAsync();
        Task<data.AspNetUserLogins> GetOneByIdWithAsync(int id);
    }
}
