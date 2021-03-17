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
    public class Productos : ICRUD<data.Productos>
    {
        private SolutionDbContext _repo = null;

        public Productos(SolutionDbContext solutionDbContext)
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.Productos t)
        {
            new DAL.Productos(_repo).Delete(t);
        }

        public IEnumerable<data.Productos> GetAll()
        {
            return new DAL.Productos(_repo).GetAll();
        }

        public data.Productos GetOneById(int id)
        {
            return new DAL.Productos(_repo).GetOneById(id);
        }

        public void Insert(data.Productos t)
        {
            new DAL.Productos(_repo).Insert(t);
        }

        public void Update(data.Productos t)
        {
            new DAL.Productos(_repo).Update(t);
        }

        public async Task<IEnumerable<data.Productos>> GetAllWithAsync()
        {
            return await new DAL.Productos(_repo).GetAllWithAsync();
        }

        public async Task<data.Productos> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Productos(_repo).GetOneByIdWithAsync(id);
        }
    }
}
