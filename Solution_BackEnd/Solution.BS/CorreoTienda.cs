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
    public class CorreoTienda : ICRUD<data.CorreoTienda>
    {
        private SolutionDbContext _repo = null;

        public CorreoTienda(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.CorreoTienda t)
        {
            new DAL.CorreoTienda(_repo).Delete(t);
        }

        public IEnumerable<data.CorreoTienda> GetAll()
        {
            return new DAL.CorreoTienda(_repo).GetAll();
        }

        public data.CorreoTienda GetOneById(int id)
        {
            return new DAL.CorreoTienda(_repo).GetOneById(id);
        }

        public void Insert(data.CorreoTienda t)
        {
            new DAL.CorreoTienda(_repo).Insert(t);
        }

        public void Update(data.CorreoTienda t)
        {
            new DAL.CorreoTienda(_repo).Update(t);
        }

        public async Task<IEnumerable<data.CorreoTienda>> GetAllWithAsync()
        {
            return await new DAL.CorreoTienda(_repo).GetAllWithAsync();
        }

        public async Task<data.CorreoTienda> GetOneByIdWithAsync(int id)
        {
            return await new DAL.CorreoTienda(_repo).GetOneByIdWithAsync(id);
        }
    }
}
