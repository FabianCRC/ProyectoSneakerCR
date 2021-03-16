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
    public class ValoracionTiendaController : ControllerBase
    {



        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public ValoracionTiendaController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ ValoracionTienda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.ValoracionTienda>>> GetValoracionTienda()
        {
            var aux = new Solution.BS.ValoracionTienda(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.ValoracionTienda>, IEnumerable<datamodels.ValoracionTienda>>(aux).ToList();
            return mapaux;
        }


        // GET: api/ValoracionTienda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.ValoracionTienda>> GetValoracionTienda(int id)
        {
            var valoraciontienda = new Solution.BS.ValoracionTienda(_context).GetOneById(id);

            if (valoraciontienda == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.ValoracionTienda, datamodels.ValoracionTienda>(valoraciontienda);
            return mapaux;
        }

        // PUT: api/ValoracionTienda/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValoracionTienda(int id, datamodels.ValoracionTienda valoraciontienda)
        {
            if (id != valoraciontienda.IdValoracion)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.ValoracionTienda, data.ValoracionTienda>(valoraciontienda);
                new Solution.BS.ValoracionTienda(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ValoracionTiendaExists(id))
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

        // POST: api/ValoracionTienda
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.ValoracionTienda>> PostValoracionTienda(datamodels.ValoracionTienda valoraciontienda)
        {
            var mapaux = _mapper.Map<datamodels.ValoracionTienda, data.ValoracionTienda>(valoraciontienda);
            new Solution.BS.ValoracionTienda(_context).Insert(mapaux);

            return CreatedAtAction("GetValoracionTienda", new { id = valoraciontienda.IdValoracion }, valoraciontienda);
        }

        // DELETE: api/ValoracionTienda/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.ValoracionTienda>> DeleteUsuarios(int id)
        {
            var valoraciontienda = new Solution.BS.ValoracionTienda(_context).GetOneById(id);
            if (valoraciontienda == null)
            {
                return NotFound();
            }

            new Solution.BS.ValoracionTienda(_context).Delete(valoraciontienda);
            var mapaux = _mapper.Map<data.ValoracionTienda, datamodels.ValoracionTienda>(valoraciontienda);

            return mapaux;
        }

        private bool ValoracionTiendaExists(int id)
        {
            return (new Solution.BS.ValoracionTienda(_context).GetOneById(id) != null);
        }


    }
}
