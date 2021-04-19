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
    public class AspNetUserRolesController : ControllerBase
    {



        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public AspNetUserRolesController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ AspNetUserRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.AspNetUserRoles>>> GetValoracionTienda()
        {
            var aux = await new Solution.BS.AspNetUserRoles(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.AspNetUserRoles>, IEnumerable<datamodels.AspNetUserRoles>>(aux).ToList();
            return mapaux;
        }


        // GET: api/ValoracionTienda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.AspNetUserRoles>> GetAspNetUserRoles(int id)
        {
            var aspNetUserRoles = await new Solution.BS.AspNetUserRoles(_context).GetOneByIdWithAsync(id);

            if (aspNetUserRoles == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.AspNetUserRoles, datamodels.AspNetUserRoles>(aspNetUserRoles);
            return mapaux;
        }

        // PUT: api/AspNetUserRoles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUserRoles(int id, datamodels.AspNetUserRoles aspNetUserRoles)
        {
            if (id != aspNetUserRoles.Id)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.AspNetUserRoles, data.AspNetUserRoles>(aspNetUserRoles);
                new Solution.BS.AspNetUserRoles(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!AspNetUserRolesExists(id))
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

        // POST: api/AspNetUserRoles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.ValoracionTienda>> PostAspNetUserRoles(datamodels.AspNetUserRoles aspNetUserRoles)
        {
            var mapaux = _mapper.Map<datamodels.AspNetUserRoles, data.AspNetUserRoles>(aspNetUserRoles);
            new Solution.BS.AspNetUserRoles(_context).Insert(mapaux);

            return CreatedAtAction("GetValoracionTienda", new { id = aspNetUserRoles.Id }, aspNetUserRoles);
        }

        // DELETE: api/AspNetUserRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.AspNetUserRoles>> DeleteAspNetUserRoles(int id)
        {
            var aspNetUserRoles = new Solution.BS.AspNetUserRoles(_context).GetOneById(id);
            if (aspNetUserRoles == null)
            {
                return NotFound();
            }

            new Solution.BS.AspNetUserRoles(_context).Delete(aspNetUserRoles);
            var mapaux = _mapper.Map<data.AspNetUserRoles, datamodels.AspNetUserRoles>(aspNetUserRoles);

            return mapaux;
        }

        private bool AspNetUserRolesExists(int id)
        {
            return (new Solution.BS.AspNetUserRoles(_context).GetOneById(id) != null);
        }


    }
}
