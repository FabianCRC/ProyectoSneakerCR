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
    public class ValoracionTienda : ICRUD<data.ValoracionTienda>
    {
        private RepositoryValoracionTienda _repo = null;

        public ValoracionTienda(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryValoracionTienda(solutionDbContext);
        }

        public void Delete(data.ValoracionTienda t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.ValoracionTienda> GetAll()
        {
            return _repo.GetAll();
        }

        public data.ValoracionTienda GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.ValoracionTienda t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.ValoracionTienda t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.ValoracionTienda>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.ValoracionTienda> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
