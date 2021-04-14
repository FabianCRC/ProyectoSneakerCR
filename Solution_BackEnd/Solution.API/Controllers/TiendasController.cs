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
    public class TiendasController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public TiendasController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Tiendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Tiendas>>> GetTiendas()
        {
            var aux = new Solution.BS.Tiendas(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.Tiendas>, IEnumerable<datamodels.Tiendas>>(aux).ToList();
            return mapaux;
        }


        // GET: api/Tiendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Tiendas>> GetTiendas(int id)
        {
            var tiendas = new Solution.BS.Tiendas(_context).GetOneById(id);

            if (tiendas == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.Tiendas, datamodels.Tiendas>(tiendas);
            return mapaux;
        }

        // PUT: api/Tiendas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiendas(int id, datamodels.Tiendas tiendas)
        {
            if (id != tiendas.IdTienda)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Tiendas, data.Tiendas>(tiendas);
                new Solution.BS.Tiendas(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!TiendasExists(id))
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

        // POST: api/Tiendas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.Tiendas>> PostTiendas(datamodels.Tiendas tiendas)
        {
            var mapaux = _mapper.Map<datamodels.Tiendas, data.Tiendas>(tiendas);
            new Solution.BS.Tiendas(_context).Insert(mapaux);

            return CreatedAtAction("GetTiendas", new { id = tiendas.IdTienda}, tiendas);
        }

        // DELETE: api/Tiendas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Tiendas>> DeleteTiendas(int id)
        {
            var tiendas = new Solution.BS.Tiendas(_context).GetOneById(id);
            if (tiendas == null)
            {
                return NotFound();
            }

            new Solution.BS.Tiendas(_context).Delete(tiendas);
            var mapaux = _mapper.Map<data.Tiendas, datamodels.Tiendas>(tiendas);

            return mapaux;
        }

        private bool TiendasExists(int id)
        {
            return (new Solution.BS.Tiendas(_context).GetOneById(id) != null);
        }
    }
}
