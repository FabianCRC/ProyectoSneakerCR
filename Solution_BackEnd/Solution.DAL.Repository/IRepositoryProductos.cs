using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryProductos : IRepository<data.Productos>
    {
        Task<IEnumerable<data.Productos>> GetAllWithAsAsync();
        Task<data.Productos> GetOneByIdWithAsync(int id);
    }
}
