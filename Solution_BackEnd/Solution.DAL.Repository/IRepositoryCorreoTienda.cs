using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryCorreoTienda : IRepository<data.CorreoTienda>
    {
        Task<IEnumerable<data.CorreoTienda>> GetAllWithAsAsync();
        Task<data.CorreoTienda> GetOneByIdWithAsync(int id);
    }
}
