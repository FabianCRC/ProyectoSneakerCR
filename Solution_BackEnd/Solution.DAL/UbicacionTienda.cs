using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
   public class UbicacionTienda : ICRUD<data.UbicacionTienda>
    {
        private RepositoryUbicacionTienda _repo = null;

        public UbicacionTienda(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryUbicacionTienda(solutionDbContext);
        }

        public void Delete(data.UbicacionTienda t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.UbicacionTienda> GetAll()
        {
            return _repo.GetAll();
        }

        public data.UbicacionTienda GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.UbicacionTienda t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.UbicacionTienda t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.UbicacionTienda>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.UbicacionTienda> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
