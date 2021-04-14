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
    public class UbicacionTiendaController : ControllerBase
    {


        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public UbicacionTiendaController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/UbicacionTienda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.UbicacionTienda>>> GetUbicacionTienda()
        {
            var aux = await new Solution.BS.UbicacionTienda(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.UbicacionTienda>, IEnumerable<datamodels.UbicacionTienda>>(aux).ToList();
            return mapaux;
        }


        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.UbicacionTienda>> GetUsuarios(int id)
        {
            var usuarios = await new Solution.BS.UbicacionTienda(_context).GetOneByIdWithAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.UbicacionTienda, datamodels.UbicacionTienda>(usuarios);
            return mapaux;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUbicacionTienda(int id, datamodels.UbicacionTienda ubicacion)
        {
            if (id != ubicacion.IdUbicacion)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.UbicacionTienda, data.UbicacionTienda>(ubicacion);
                new Solution.BS.UbicacionTienda(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!UbicacionTiendaExists(id))
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
        public async Task<ActionResult<datamodels.UbicacionTienda>> PostUbicacionTienda(datamodels.UbicacionTienda ubicacion)
        {
            var mapaux = _mapper.Map<datamodels.UbicacionTienda, data.UbicacionTienda>(ubicacion);
            new Solution.BS.UbicacionTienda(_context).Insert(mapaux);

            return CreatedAtAction("GetUbicacionTienda", new { id = ubicacion.IdUbicacion }, ubicacion);
        }

        // DELETE: api/UbicacionTienda/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.UbicacionTienda>> DeleteUbicacionTienda(int id)
        {
            var ubicacion = new Solution.BS.UbicacionTienda(_context).GetOneById(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            new Solution.BS.UbicacionTienda(_context).Delete(ubicacion);
            var mapaux = _mapper.Map<data.UbicacionTienda, datamodels.UbicacionTienda>(ubicacion);

            return mapaux;
        }

        private bool UbicacionTiendaExists(int id)
        {
            return (new Solution.BS.UbicacionTienda(_context).GetOneById(id) != null);
        }

    }
}
