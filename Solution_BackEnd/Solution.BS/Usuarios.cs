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
    public class Usuarios : ICRUD<data.Usuarios>
    {
        private SolutionDbContext _repo = null;

        public Usuarios(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.Usuarios t)
        {
            new DAL.Usuarios(_repo).Delete(t);
        }

        public IEnumerable<data.Usuarios> GetAll()
        {
            return new DAL.Usuarios(_repo).GetAll();
        }

        public data.Usuarios GetOneById(int id)
        {
            return new DAL.Usuarios(_repo).GetOneById(id);
        }

        public void Insert(data.Usuarios t)
        {
            new DAL.Usuarios(_repo).Insert(t);
        }

        public void Update(data.Usuarios t)
        {
            new DAL.Usuarios(_repo).Update(t);
        }

        public async Task<IEnumerable<data.Usuarios>> GetAllWithAsync()
        {
            return await new DAL.Usuarios(_repo).GetAllWithAsync();
        }

        public async Task<data.Usuarios> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Usuarios(_repo).GetOneByIdWithAsync(id);
        }
    }
}
