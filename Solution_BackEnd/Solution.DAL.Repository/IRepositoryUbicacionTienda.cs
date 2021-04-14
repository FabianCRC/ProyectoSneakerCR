using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryUbicacionTienda : IRepository<data.UbicacionTienda>
    {
        Task<IEnumerable<data.UbicacionTienda>> GetAllWithAsAsync();
        Task<data.UbicacionTienda> GetOneByIdWithAsync(int id);
    }
}
