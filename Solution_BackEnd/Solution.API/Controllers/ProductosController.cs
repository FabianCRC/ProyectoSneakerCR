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
    public class ProductosController : ControllerBase
    {


        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public ProductosController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Productos>>> GetProductos()
        {
            var aux = await new Solution.BS.Productos(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Productos>, IEnumerable<datamodels.Productos>>(aux).ToList();
            return mapaux;
        }


        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Productos>> GetProductos(int id)
        {
            var productos = await new Solution.BS.Productos(_context).GetOneByIdWithAsync(id);

            if (productos == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.Productos, datamodels.Productos>(productos);
            return mapaux;
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductos(int id, datamodels.Productos productos)
        {
            if (id != productos.IdProducto)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Productos, data.Productos>(productos);
                new Solution.BS.Productos(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ProductosExists(id))
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

        // POST: api/Productos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.Productos>> PostProductos(datamodels.Productos productos)
        {
            var mapaux = _mapper.Map<datamodels.Productos, data.Productos>(productos);
            new Solution.BS.Productos(_context).Insert(mapaux);

            return CreatedAtAction("GetProductos", new { id = productos.IdProducto }, productos);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Productos>> DeleteProductos(int id)
        {
            var productos = new Solution.BS.Productos(_context).GetOneById(id);
            if (productos == null)
            {
                return NotFound();
            }

            new Solution.BS.Productos(_context).Delete(productos);
            var mapaux = _mapper.Map<data.Productos, datamodels.Productos>(productos);

            return mapaux;
        }

        private bool ProductosExists(int id)
        {
            return (new Solution.BS.Productos(_context).GetOneById(id) != null);
        }

    }
}