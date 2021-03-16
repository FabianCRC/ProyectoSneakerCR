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
    public class ValoracionTienda : ICRUD<data.ValoracionTienda>
    {
        private SolutionDbContext _repo = null;

        public ValoracionTienda(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.ValoracionTienda t)
        {
            new DAL.ValoracionTienda(_repo).Delete(t);
        }

        public IEnumerable<data.ValoracionTienda> GetAll()
        {
            return new DAL.ValoracionTienda(_repo).GetAll();
        }

        public data.ValoracionTienda GetOneById(int id)
        {
            return new DAL.ValoracionTienda(_repo).GetOneById(id);
        }

        public void Insert(data.ValoracionTienda t)
        {
            new DAL.ValoracionTienda(_repo).Insert(t);
        }

        public void Update(data.ValoracionTienda t)
        {
            new DAL.ValoracionTienda(_repo).Update(t);
        }

        public async Task<IEnumerable<data.ValoracionTienda>> GetAllWithAsync()
        {
            return await new DAL.ValoracionTienda(_repo).GetAllWithAsync();
        }

        public async Task<data.ValoracionTienda> GetOneByIdWithAsync(int id)
        {
            return await new DAL.ValoracionTienda(_repo).GetOneByIdWithAsync(id);
        }
    }
}
