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
    public class CorreoTienda : ICRUD<data.CorreoTienda>
    {
        private RepositoryCorreoTienda _repo = null;

        public CorreoTienda(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryCorreoTienda(solutionDbContext);
        }

        public void Delete(data.CorreoTienda t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.CorreoTienda> GetAll()
        {
            return _repo.GetAll();
        }

        public data.CorreoTienda GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.CorreoTienda t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.CorreoTienda t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.CorreoTienda>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.CorreoTienda> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
