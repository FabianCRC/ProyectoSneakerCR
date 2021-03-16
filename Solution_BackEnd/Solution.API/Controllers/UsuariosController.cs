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
    public class UsuariosController : ControllerBase
    {


        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public UsuariosController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Usuarios>>> GetUsuarios()
        {
            var aux = await new Solution.BS.Usuarios(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Usuarios>, IEnumerable<datamodels.Usuarios>>(aux).ToList();
            return mapaux;
        }


        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Usuarios>> GetUsuarios(int id)
        {
            var usuarios = await new Solution.BS.Usuarios(_context).GetOneByIdWithAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.Usuarios, datamodels.Usuarios>(usuarios);
            return mapaux;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(int id, datamodels.Usuarios usuarios)
        {
            if (id != usuarios.IdUsuario)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Usuarios, data.Usuarios>(usuarios);
                new Solution.BS.Usuarios(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!UsuariosExists(id))
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
        public async Task<ActionResult<datamodels.Usuarios>> PostUsuarios(datamodels.Usuarios usuarios)
        {
            var mapaux = _mapper.Map<datamodels.Usuarios, data.Usuarios>(usuarios);
            new Solution.BS.Usuarios(_context).Insert(mapaux);

            return CreatedAtAction("GetUsuarios", new { id = usuarios.IdUsuario }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Usuarios>> DeleteUsuarios(int id)
        {
            var usuarios = new Solution.BS.Usuarios(_context).GetOneById(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            new Solution.BS.Usuarios(_context).Delete(usuarios);
            var mapaux = _mapper.Map<data.Usuarios, datamodels.Usuarios>(usuarios);

            return mapaux;
        }

        private bool UsuariosExists(int id)
        {
            return (new Solution.BS.Usuarios(_context).GetOneById(id) != null);
        }

    }
}
