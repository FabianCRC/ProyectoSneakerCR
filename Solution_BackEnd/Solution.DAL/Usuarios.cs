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
    public class Usuarios : ICRUD<data.Usuarios>
    {
        private RepositoryUsuarios _repo = null;

        public Usuarios(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryUsuarios(solutionDbContext);
        }

        public void Delete(data.Usuarios t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Usuarios> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Usuarios GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Usuarios t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Usuarios t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Usuarios>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.Usuarios> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
