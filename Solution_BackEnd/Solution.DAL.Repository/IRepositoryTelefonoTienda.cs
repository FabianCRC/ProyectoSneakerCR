using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryTelefonoTienda : IRepository<data.TelefonoTienda>
    {
        Task<IEnumerable<data.TelefonoTienda>> GetAllWithAsAsync();
        Task<data.TelefonoTienda> GetOneByIdWithAsync(int id);
    }
}