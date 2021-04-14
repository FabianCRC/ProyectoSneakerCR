using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class UbicacionTienda : ICRUD<data.UbicacionTienda>
    {
        private SolutionDbContext _repo = null;

        public UbicacionTienda(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.UbicacionTienda t)
        {
            new DAL.UbicacionTienda(_repo).Delete(t);
        }

        public IEnumerable<data.UbicacionTienda> GetAll()
        {
            return new DAL.UbicacionTienda(_repo).GetAll();
        }

        public data.UbicacionTienda GetOneById(int id)
        {
            return new DAL.UbicacionTienda(_repo).GetOneById(id);
        }

        public void Insert(data.UbicacionTienda t)
        {
            new DAL.UbicacionTienda(_repo).Insert(t);
        }

        public void Update(data.UbicacionTienda t)
        {
            new DAL.UbicacionTienda(_repo).Update(t);
        }

        public async Task<IEnumerable<data.UbicacionTienda>> GetAllWithAsync()
        {
            return await new DAL.UbicacionTienda(_repo).GetAllWithAsync();
        }

        public async Task<data.UbicacionTienda> GetOneByIdWithAsync(int id)
        {
            return await new DAL.UbicacionTienda(_repo).GetOneByIdWithAsync(id);
        }
    }
}