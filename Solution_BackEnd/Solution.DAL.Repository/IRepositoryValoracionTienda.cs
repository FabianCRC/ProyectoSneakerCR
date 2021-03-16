using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryValoracionTienda : IRepository<data.ValoracionTienda>
    {
        Task<IEnumerable<data.ValoracionTienda>> GetAllWithAsAsync();
        Task<data.ValoracionTienda> GetOneByIdWithAsync(int id);
    }
}
