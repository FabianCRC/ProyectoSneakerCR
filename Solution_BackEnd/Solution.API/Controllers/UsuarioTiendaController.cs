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
    public class UsuarioTiendaController : ControllerBase
    {



        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioTiendaController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/UsuarioTienda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.UsuarioTienda>>> GetUsuarioTienda()
        {
            var aux = await new Solution.BS.UsuarioTienda(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.UsuarioTienda>, IEnumerable<datamodels.UsuarioTienda>>(aux).ToList();
            return mapaux;
        }


        // GET: api/UsuarioTienda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.UsuarioTienda>> GetUsuarioTienda(int id)
        {
            var usuariotienda = await new Solution.BS.UsuarioTienda(_context).GetOneByIdWithAsync(id);

            if (usuariotienda == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.UsuarioTienda, datamodels.UsuarioTienda>(usuariotienda);
            return mapaux;
        }

        // PUT: api/UsuarioTienda/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioTienda(int id, datamodels.UsuarioTienda usuariotienda)
        {
            if (id != usuariotienda.IdUsuario)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.UsuarioTienda, data.UsuarioTienda>(usuariotienda);
                new Solution.BS.UsuarioTienda(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!UsuarioTiendaExists(id))
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

        // POST: api/UsuarioTienda
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.UsuarioTienda>> PostUsuarioTienda(datamodels.UsuarioTienda usuariotienda)
        {
            var mapaux = _mapper.Map<datamodels.UsuarioTienda, data.UsuarioTienda>(usuariotienda);
            new Solution.BS.UsuarioTienda(_context).Insert(mapaux);

            return CreatedAtAction("GetUsuarioTienda", new { id = usuariotienda.IdUsuarioTienda }, usuariotienda);
        }

        // DELETE: api/UsuarioTienda/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.UsuarioTienda>> DeleteUsuarioTienda(int id)
        {
            var usuariotienda = new Solution.BS.UsuarioTienda(_context).GetOneById(id);
            if (usuariotienda == null)
            {
                return NotFound();
            }

            new Solution.BS.UsuarioTienda(_context).Delete(usuariotienda);
            var mapaux = _mapper.Map<data.UsuarioTienda, datamodels.UsuarioTienda>(usuariotienda);

            return mapaux;
        }

        private bool UsuarioTiendaExists(int id)
        {
            return (new Solution.BS.UsuarioTienda(_context).GetOneById(id) != null);
        }


    }
}
