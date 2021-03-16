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
    public class UsuarioTienda : ICRUD<data.UsuarioTienda>
    {
        private RepositoryUsuarioTienda _repo = null;

        public UsuarioTienda(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryUsuarioTienda(solutionDbContext);
        }

        public void Delete(data.UsuarioTienda t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.UsuarioTienda> GetAll()
        {
            return _repo.GetAll();
        }

        public data.UsuarioTienda GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.UsuarioTienda t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.UsuarioTienda t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.UsuarioTienda>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.UsuarioTienda> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
