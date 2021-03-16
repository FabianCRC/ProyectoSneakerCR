using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryUsuarioTienda : IRepository<data.UsuarioTienda>
    {
        Task<IEnumerable<data.UsuarioTienda>> GetAllWithAsAsync();
        Task<data.UsuarioTienda> GetOneByIdWithAsync(int id);
    }
}
