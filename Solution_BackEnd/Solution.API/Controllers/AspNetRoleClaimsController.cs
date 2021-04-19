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
    public class AspNetRoleClaimsController : ControllerBase
    {



        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public AspNetRoleClaimsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ AspNetRoleClaims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.AspNetRoleClaims>>> GetAspNetRoleClaims()
        {
            var aux = await new Solution.BS.AspNetRoleClaims(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.AspNetRoleClaims>, IEnumerable<datamodels.AspNetRoleClaims>>(aux).ToList();
            return mapaux;
        }


        // GET: api/AspNetRoleClaims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.AspNetRoleClaims>> GetValoracionTienda(int id)
        {
            var aspNetRoleClaims = await new Solution.BS.AspNetRoleClaims(_context).GetOneByIdWithAsync(id);

            if (aspNetRoleClaims == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.AspNetRoleClaims, datamodels.AspNetRoleClaims>(aspNetRoleClaims);
            return mapaux;
        }

        // PUT: api/AspNetRoleClaims/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetRoleClaims(int id, datamodels.AspNetRoleClaims aspNetRoleClaims)
        {
            if (id != aspNetRoleClaims.Id)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.AspNetRoleClaims, data.ValoracionTienda>(aspNetRoleClaims);
                new Solution.BS.ValoracionTienda(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!AspNetRoleClaimsExists(id))
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

        // POST: api/AspNetRoleClaims
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.AspNetRoleClaims>> PostAspNetRoleClaims(datamodels.AspNetRoleClaims aspNetRoleClaims)
        {
            var mapaux = _mapper.Map<datamodels.AspNetRoleClaims, data.AspNetRoleClaims>(aspNetRoleClaims);
            new Solution.BS.AspNetRoleClaims(_context).Insert(mapaux);

            return CreatedAtAction("GetAspNetRoleClaims", new { id = aspNetRoleClaims.Id }, aspNetRoleClaims);
        }

        // DELETE: api/AspNetRoleClaims/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.AspNetRoleClaims>> DeleteAspNetRoleClaims(int id)
        {
            var aspNetRoleClaims = new Solution.BS.AspNetRoleClaims(_context).GetOneById(id);
            if (aspNetRoleClaims == null)
            {
                return NotFound();
            }

            new Solution.BS.AspNetRoleClaims(_context).Delete(aspNetRoleClaims);
            var mapaux = _mapper.Map<data.AspNetRoleClaims, datamodels.AspNetRoleClaims>(aspNetRoleClaims);

            return mapaux;
        }

        private bool AspNetRoleClaimsExists(int id)
        {
            return (new Solution.BS.AspNetRoleClaims(_context).GetOneById(id) != null);
        }


    }
}
