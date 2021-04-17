using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solution.DAL.EF;
using AutoMapper;
using datamodels = Solution.API.DataModels;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaProductosController : ControllerBase
    {

        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public MarcaProductosController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/MarcaProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.MarcaProductos>>> GetMarcaProductos()
        {
            var aux = new Solution.BS.MarcaProductos(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.MarcaProductos>, IEnumerable<datamodels.MarcaProductos>>(aux).ToList();
            return mapaux;
        }


        // GET: api/MarcaProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.MarcaProductos>> GetMarcaProductos(int id)
        {
            var marcaProductos = new Solution.BS.MarcaProductos(_context).GetOneById(id);

            if (marcaProductos == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.MarcaProductos, datamodels.MarcaProductos>(marcaProductos);
            return mapaux;
        }

        // PUT: api/MarcaProductos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarcaProductos(int id, datamodels.MarcaProductos marcaProductos)
        {
            if (id != marcaProductos.IdMarca)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.MarcaProductos, data.MarcaProductos>(marcaProductos);
                new Solution.BS.MarcaProductos(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!MarcaProductosExists(id))
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

        // POST: api/MarcaProductos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.MarcaProductos>> PostMarcaProductos(datamodels.MarcaProductos marcaProductos)
        {
            var mapaux = _mapper.Map<datamodels.MarcaProductos, data.MarcaProductos>(marcaProductos);
            new Solution.BS.MarcaProductos(_context).Insert(mapaux);

            return CreatedAtAction("GetMarcaProductos", new { id = marcaProductos.IdMarca }, marcaProductos);
        }

        // DELETE: api/MarcaProductos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.MarcaProductos>> DeleteMarcaProductos(int id)
        {
            var marcaProductos = new Solution.BS.MarcaProductos(_context).GetOneById(id);
            if (marcaProductos == null)
            {
                return NotFound();
            }

            new Solution.BS.MarcaProductos(_context).Delete(marcaProductos);
            var mapaux = _mapper.Map<data.MarcaProductos, datamodels.MarcaProductos>(marcaProductos);

            return mapaux;
        }

        private bool MarcaProductosExists(int id)
        {
            return (new Solution.BS.MarcaProductos(_context).GetOneById(id) != null);
        }

    }
}
