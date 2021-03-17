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
    public class TelefonoTienda : ICRUD<data.TelefonoTienda>
    {
        private RepositoryTelefonoTienda _repo = null;

        public TelefonoTienda(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryTelefonoTienda(solutionDbContext);
        }

        public void Delete(data.TelefonoTienda t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.TelefonoTienda> GetAll()
        {
            return _repo.GetAll();
        }

        public data.TelefonoTienda GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.TelefonoTienda t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.TelefonoTienda t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.TelefonoTienda>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.TelefonoTienda> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
