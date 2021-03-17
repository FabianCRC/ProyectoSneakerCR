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
    public class TelefonoTienda : ICRUD<data.TelefonoTienda>
    {
        private SolutionDbContext _repo = null;

        public TelefonoTienda(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.TelefonoTienda t)
        {
            new DAL.TelefonoTienda(_repo).Delete(t);
        }

        public IEnumerable<data.TelefonoTienda> GetAll()
        {
            return new DAL.TelefonoTienda(_repo).GetAll();
        }

        public data.TelefonoTienda GetOneById(int id)
        {
            return new DAL.TelefonoTienda(_repo).GetOneById(id);
        }

        public void Insert(data.TelefonoTienda t)
        {
            new DAL.TelefonoTienda(_repo).Insert(t);
        }

        public void Update(data.TelefonoTienda t)
        {
            new DAL.TelefonoTienda(_repo).Update(t);
        }

        public async Task<IEnumerable<data.TelefonoTienda>> GetAllWithAsync()
        {
            return await new DAL.TelefonoTienda(_repo).GetAllWithAsync();
        }

        public async Task<data.TelefonoTienda> GetOneByIdWithAsync(int id)
        {
            return await new DAL.TelefonoTienda(_repo).GetOneByIdWithAsync(id);
        }
    }
}
