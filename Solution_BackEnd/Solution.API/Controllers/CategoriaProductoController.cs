using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datamodels = Solution.API.DataModels;
using data = Solution.DO.Objects;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaProductoController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public CategoriaProductoController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CategoriaProcuto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.CategoriaProductos>>> GetCategoriaProductos()
        {
            var aux = new Solution.BS.CategoriaProductos(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.CategoriaProductos>, IEnumerable<datamodels.CategoriaProductos>>(aux).ToList();
            return mapaux;
        }


        // GET: api/CategoriaProductoController/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.CategoriaProductos>> GetRoles(int id)
        {
            var categoriaProductos = new Solution.BS.CategoriaProductos(_context).GetOneById(id);

            if (categoriaProductos == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.CategoriaProductos, datamodels.CategoriaProductos>(categoriaProductos);
            return mapaux;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaProductos(int id, datamodels.CategoriaProductos categoriaProductos)
        {
            if (id != categoriaProductos.IdCategoria)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.CategoriaProductos, data.CategoriaProductos>(categoriaProductos);
                new Solution.BS.CategoriaProductos(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!CategoriaProductosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clase
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.CategoriaProductos>> PostCategoriaProductos(datamodels.CategoriaProductos categoriaProductos)
        {
            var mapaux = _mapper.Map<datamodels.CategoriaProductos, data.CategoriaProductos>(categoriaProductos);
            new Solution.BS.CategoriaProductos(_context).Insert(mapaux);

            return CreatedAtAction("GetCategoriaProductos", new { id = categoriaProductos.IdCategoria }, categoriaProductos);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.CategoriaProductos>> DeleteCategoriaProductos(int id)
        {
            var categoriaProductos = new Solution.BS.CategoriaProductos(_context).GetOneById(id);
            if (categoriaProductos == null)
            {
                return NotFound();
            }

            new Solution.BS.CategoriaProductos(_context).Delete(categoriaProductos);
            var mapaux = _mapper.Map<data.CategoriaProductos, datamodels.CategoriaProductos>(categoriaProductos);

            return mapaux;
        }

        private bool CategoriaProductosExists(int id)
        {
            return (new Solution.BS.CategoriaProductos(_context).GetOneById(id) != null);
        }
    }
}
