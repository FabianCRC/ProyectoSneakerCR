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
    public class RolesController : ControllerBase
    {

        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public RolesController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Roles>>> GetRoles()
        {
            var aux = new Solution.BS.Roles(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.Roles>, IEnumerable<datamodels.Roles>>(aux).ToList();
            return mapaux;
        }


        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Roles>> GetRoles(int id)
        {
            var roles = new Solution.BS.Roles(_context).GetOneById(id);

            if (roles == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.Roles, datamodels.Roles>(roles);
            return mapaux;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id, datamodels.Roles roles)
        {
            if (id != roles.IdRol)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Roles, data.Roles>(roles);
                new Solution.BS.Roles(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!RolesExists(id))
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
        public async Task<ActionResult<datamodels.Roles>> PostRoles(datamodels.Roles roles)
        {
            var mapaux = _mapper.Map<datamodels.Roles, data.Roles>(roles);
            new Solution.BS.Roles(_context).Insert(mapaux);

            return CreatedAtAction("GetRoles", new { id = roles.IdRol }, roles);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Roles>> DeleteRoles(int id)
        {
            var roles = new Solution.BS.Roles(_context).GetOneById(id);
            if (roles == null)
            {
                return NotFound();
            }

            new Solution.BS.Roles(_context).Delete(roles);
            var mapaux = _mapper.Map<data.Roles, datamodels.Roles>(roles);

            return mapaux;
        }

        private bool RolesExists(int id)
        {
            return (new Solution.BS.Roles(_context).GetOneById(id) != null);
        }

    }
}
