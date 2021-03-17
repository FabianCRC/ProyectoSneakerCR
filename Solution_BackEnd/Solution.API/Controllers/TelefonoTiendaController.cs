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
    public class TelefonoTiendaController : ControllerBase
    {


        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public TelefonoTiendaController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TelefonoTienda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.TelefonoTienda>>> GetUsuarios()
        {
            var aux = await new Solution.BS.TelefonoTienda(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.TelefonoTienda>, IEnumerable<datamodels.TelefonoTienda>>(aux).ToList();
            return mapaux;
        }


        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.TelefonoTienda>> GetUsuarios(int id)
        {
            var telefonoTienda = await new Solution.BS.TelefonoTienda(_context).GetOneByIdWithAsync(id);

            if (telefonoTienda == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.TelefonoTienda, datamodels.TelefonoTienda>(telefonoTienda);
            return mapaux;
        }

        // PUT: api/TelefonoTienda/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelefonoTienda(int id, datamodels.TelefonoTienda telefonoTienda)
        {
            if (id != telefonoTienda.IdTelefono)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.TelefonoTienda, data.TelefonoTienda>(telefonoTienda);
                new Solution.BS.TelefonoTienda(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!TelefonoTiendaExists(id))
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

        // POST: api/TelefonoTienda
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.TelefonoTienda>> PostUsuarios(datamodels.TelefonoTienda telefonoTienda)
        {
            var mapaux = _mapper.Map<datamodels.TelefonoTienda, data.TelefonoTienda>(telefonoTienda);
            new Solution.BS.TelefonoTienda(_context).Insert(mapaux);

            return CreatedAtAction("GetTelefonoTienda", new { id = telefonoTienda.IdTelefono }, telefonoTienda);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.TelefonoTienda>> DeleteTelefonoTienda(int id)
        {
            var telefonoTienda = new Solution.BS.TelefonoTienda(_context).GetOneById(id);
            if (telefonoTienda == null)
            {
                return NotFound();
            }

            new Solution.BS.TelefonoTienda(_context).Delete(telefonoTienda);
            var mapaux = _mapper.Map<data.TelefonoTienda, datamodels.TelefonoTienda>(telefonoTienda);

            return mapaux;
        }

        private bool TelefonoTiendaExists(int id)
        {
            return (new Solution.BS.TelefonoTienda(_context).GetOneById(id) != null);
        }

    }

}
