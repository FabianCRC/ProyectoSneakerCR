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
    public class UsuarioTienda : ICRUD<data.UsuarioTienda>
    {
        private SolutionDbContext _repo = null;

        public UsuarioTienda(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.UsuarioTienda t)
        {
            new DAL.UsuarioTienda(_repo).Delete(t);
        }

        public IEnumerable<data.UsuarioTienda> GetAll()
        {
            return new DAL.UsuarioTienda(_repo).GetAll();
        }

        public data.UsuarioTienda GetOneById(int id)
        {
            return new DAL.UsuarioTienda(_repo).GetOneById(id);
        }

        public void Insert(data.UsuarioTienda t)
        {
            new DAL.UsuarioTienda(_repo).Insert(t);
        }

        public void Update(data.UsuarioTienda t)
        {
            new DAL.UsuarioTienda(_repo).Update(t);
        }

        public async Task<IEnumerable<data.UsuarioTienda>> GetAllWithAsync()
        {
            return await new DAL.UsuarioTienda(_repo).GetAllWithAsync();
        }

        public async Task<data.UsuarioTienda> GetOneByIdWithAsync(int id)
        {
            return await new DAL.UsuarioTienda(_repo).GetOneByIdWithAsync(id);
        }
    }
}
