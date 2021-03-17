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
    public class Productos : ICRUD<data.Productos>
    {
        private RepositoryProductos _repo = null;

        public Productos(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryProductos(solutionDbContext);
        }

        public void Delete(data.Productos t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Productos> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Productos GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Productos t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Productos t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Productos>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.Productos> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
