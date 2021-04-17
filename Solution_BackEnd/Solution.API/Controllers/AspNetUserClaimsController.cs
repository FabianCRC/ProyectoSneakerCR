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
    public class AspNetUserClaimsController : ControllerBase
    {


        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public AspNetUserClaimsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AspNetUserClaims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.AspNetUserClaims>>> GetAspNetUserClaims()
        {
            var aux = await new Solution.BS.AspNetUserClaims(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.AspNetUserClaims>, IEnumerable<datamodels.AspNetUserClaims>>(aux).ToList();
            return mapaux;
        }


        // GET: api/AspNetUserClaims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.AspNetUserClaims>> GetAspNetUserClaims(int id)
        {
            var aspnetuserclaims = await new Solution.BS.AspNetUserClaims(_context).GetOneByIdWithAsync(id);

            if (aspnetuserclaims == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.AspNetUserClaims, datamodels.AspNetUserClaims>(aspnetuserclaims);
            return mapaux;
        }

        // PUT: api/AspNetUserClaims/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUserClaims(int id, datamodels.AspNetUserClaims aspnetuserclaims)
        {
            if (id != aspnetuserclaims.Id)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.AspNetUserClaims, data.AspNetUserClaims>(aspnetuserclaims);
                new Solution.BS.AspNetUserClaims(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!AspNetUserClaimsExists(id))
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

        // POST: api/AspNetUserClaims
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.AspNetUserClaims>> PostAspNetUserClaims(datamodels.AspNetUserClaims aspnetuserclaims)
        {
            var mapaux = _mapper.Map<datamodels.AspNetUserClaims, data.AspNetUserClaims>(aspnetuserclaims);
            new Solution.BS.AspNetUserClaims(_context).Insert(mapaux);

            return CreatedAtAction("GetAspNetUserClaims", new { id = aspnetuserclaims.Id }, aspnetuserclaims);
        }

        // DELETE: api/AspNetUserClaims/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.AspNetUserClaims>> DeleteAspNetUserClaims(int id)
        {
            var aspnetuserclaims = new Solution.BS.AspNetUserClaims(_context).GetOneById(id);
            if (aspnetuserclaims == null)
            {
                return NotFound();
            }

            new Solution.BS.AspNetUserClaims(_context).Delete(aspnetuserclaims);
            var mapaux = _mapper.Map<data.AspNetUserClaims, datamodels.AspNetUserClaims>(aspnetuserclaims);

            return mapaux;
        }

        private bool AspNetUserClaimsExists(int id)
        {
            return (new Solution.BS.AspNetUserClaims(_context).GetOneById(id) != null);
        }

    }
}
