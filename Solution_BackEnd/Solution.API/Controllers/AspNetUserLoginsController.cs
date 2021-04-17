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
    public class AspNetUserLoginsController : ControllerBase
    {


        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public AspNetUserLoginsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AspNetUserLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.AspNetUserLogins>>> GetAspNetUserLogins()
        {
            var aux = await new Solution.BS.AspNetUserLogins(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.AspNetUserLogins>, IEnumerable<datamodels.AspNetUserLogins>>(aux).ToList();
            return mapaux;
        }


        // GET: api/AspNetUserLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.AspNetUserLogins>> GetAspNetUserLogins(int id)
        {
            var aspnetuserlogins = await new Solution.BS.AspNetUserLogins(_context).GetOneByIdWithAsync(id);

            if (aspnetuserlogins == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.AspNetUserLogins, datamodels.AspNetUserLogins>(aspnetuserlogins);
            return mapaux;
        }

        // PUT: api/AspNetUserLogins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUserLogins(int id, datamodels.AspNetUserLogins aspnetuserlogins)
        {
            if (!id.Equals(aspnetuserlogins.ProviderKey))
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.AspNetUserLogins, data.AspNetUserLogins>(aspnetuserlogins);
                new Solution.BS.AspNetUserLogins(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!AspNetUserLoginsExists(id))
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

        // POST: api/AspNetUserLogins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.AspNetUserLogins>> PostAspNetUserLogins(datamodels.AspNetUserLogins aspnetuserlogins)
        {
            var mapaux = _mapper.Map<datamodels.AspNetUserLogins, data.AspNetUserLogins>(aspnetuserlogins);
            new Solution.BS.AspNetUserLogins(_context).Insert(mapaux);

            return CreatedAtAction("GetAspNetUserLogins", new { id = aspnetuserlogins.ProviderKey }, aspnetuserlogins);
        }

        // DELETE: api/AspNetUserLogins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.AspNetUserLogins>> DeleteAspNetUserLogins(int id)
        {
            var aspnetuserlogins = new Solution.BS.AspNetUserLogins(_context).GetOneById(id);
            if (aspnetuserlogins == null)
            {
                return NotFound();
            }

            new Solution.BS.AspNetUserLogins(_context).Delete(aspnetuserlogins);
            var mapaux = _mapper.Map<data.AspNetUserLogins, datamodels.AspNetUserLogins>(aspnetuserlogins);

            return mapaux;
        }

        private bool AspNetUserLoginsExists(int id)
        {
            return (new Solution.BS.AspNetUserLogins(_context).GetOneById(id) != null);
        }

    }
}
