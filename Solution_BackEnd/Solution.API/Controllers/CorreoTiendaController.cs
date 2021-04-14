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


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorreoTiendaController : ControllerBase
    {


        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public CorreoTiendaController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.CorreoTienda>>> GetCorreoTienda()
        {
            var aux = await new Solution.BS.CorreoTienda(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.CorreoTienda>, IEnumerable<datamodels.CorreoTienda>>(aux).ToList();
            return mapaux;
        }


        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.CorreoTienda>> GetCorreoTienda(int id)
        {
            var correotienda = await new Solution.BS.CorreoTienda(_context).GetOneByIdWithAsync(id);

            if (correotienda == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.CorreoTienda, datamodels.CorreoTienda>(correotienda);
            return mapaux;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorreoTienda(int id, datamodels.CorreoTienda correotienda)
        {
            if (id != correotienda.IdTienda)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.CorreoTienda, data.CorreoTienda>(correotienda);
                new Solution.BS.CorreoTienda(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!CorreoTiendaExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.CorreoTienda>> PostCorreoTienda(datamodels.CorreoTienda correotienda)
        {
            var mapaux = _mapper.Map<datamodels.CorreoTienda, data.CorreoTienda>(correotienda);
            new Solution.BS.CorreoTienda(_context).Insert(mapaux);

            return CreatedAtAction("GetCorreoTienda", new { id = correotienda.IdCorreo}, correotienda);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.CorreoTienda>> DeleteCorreoTienda(int id)
        {
            var correotienda = new Solution.BS.CorreoTienda(_context).GetOneById(id);
            if (correotienda == null)
            {
                return NotFound();
            }

            new Solution.BS.CorreoTienda(_context).Delete(correotienda);
            var mapaux = _mapper.Map<data.CorreoTienda, datamodels.CorreoTienda>(correotienda);

            return mapaux;
        }

        private bool CorreoTiendaExists(int id)
        {
            return (new Solution.BS.CorreoTienda(_context).GetOneById(id) != null);
        }

    }
}
