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
    public class AspNetRolesController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public AspNetRolesController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AspNetRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.AspNetRoles>>> GetAspNetRoles()
        {
            var aux = new Solution.BS.AspNetRoles(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.AspNetRoles>, IEnumerable<datamodels.AspNetRoles>>(aux).ToList();
            return mapaux;
        }


        // GET: api/AspNetRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.AspNetRoles>> GetAspNetRoles(int id)
        {
            var aspNetRoles = new Solution.BS.AspNetRoles(_context).GetOneById(id);

            if (aspNetRoles == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.AspNetRoles, datamodels.AspNetRoles>(aspNetRoles);
            return mapaux;
        }

        // PUT: api/AspNetRoles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetRoles(int id, datamodels.AspNetRoles aspNetRoles)
        {
            if (id.Equals(aspNetRoles.Id))
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.AspNetRoles, data.AspNetRoles>(aspNetRoles);
                new Solution.BS.AspNetRoles(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!AspNetRolesExists(id))
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
        public async Task<ActionResult<datamodels.AspNetUsers>> PostAspNetRoles(datamodels.AspNetRoles aspNetRoles)
        {
            var mapaux = _mapper.Map<datamodels.AspNetRoles, data.AspNetRoles>(aspNetRoles);
            new Solution.BS.AspNetRoles(_context).Insert(mapaux);

            return CreatedAtAction("GetAspNetRoles", new { id = aspNetRoles.Id }, aspNetRoles);
        }

        // DELETE: api/AspNetRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.AspNetRoles>> DeleteAspNetRoles(int id)
        {
            var aspNetRoles = new Solution.BS.AspNetRoles(_context).GetOneById(id);
            if (aspNetRoles == null)
            {
                return NotFound();
            }

            new Solution.BS.AspNetRoles(_context).Delete(aspNetRoles);
            var mapaux = _mapper.Map<data.AspNetRoles, datamodels.AspNetRoles>(aspNetRoles);

            return mapaux;
        }

        private bool AspNetRolesExists(int id)
        {
            return (new Solution.BS.AspNetRoles(_context).GetOneById(id) != null);
        }
        
    }
}
