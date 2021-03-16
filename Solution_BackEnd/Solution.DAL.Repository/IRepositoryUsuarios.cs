using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryUsuarios : IRepository<data.Usuarios>
    {
        Task<IEnumerable<data.Usuarios>> GetAllWithAsAsync();
        Task<data.Usuarios> GetOneByIdWithAsync(int id);
    }
}
