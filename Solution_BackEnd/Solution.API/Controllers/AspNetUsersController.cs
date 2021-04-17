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
    public class AspNetUsersController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        private readonly IMapper _mapper;

        public AspNetUsersController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AspNetUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.AspNetUsers>>> GetAspNetUsers()
        {
            var aux = new Solution.BS.AspNetUsers(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.AspNetUsers>, IEnumerable<datamodels.AspNetUsers>>(aux).ToList();
            return mapaux;
        }


        // GET: api/AspNetUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.AspNetUsers>> GetAspNetUsers(int id)
        {
            var aspnetusers = new Solution.BS.AspNetUsers(_context).GetOneById(id);

            if (aspnetusers == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.AspNetUsers, datamodels.AspNetUsers>(aspnetusers);
            return mapaux;
        }

        // PUT: api/AspNetUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUsers(int id, datamodels.AspNetUsers aspnetusers)
        {
            if (!id.Equals( aspnetusers.Id))
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.AspNetUsers, data.AspNetUsers>(aspnetusers);
                new Solution.BS.AspNetUsers(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!AspNetUsersExists(id))
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
        public async Task<ActionResult<datamodels.AspNetUsers>> PostAspNetUsers(datamodels.AspNetUsers aspnetusers)
        {
            var mapaux = _mapper.Map<datamodels.AspNetUsers, data.AspNetUsers>(aspnetusers);
            new Solution.BS.AspNetUsers(_context).Insert(mapaux);

            return CreatedAtAction("GetAspNetUsers", new { id = aspnetusers.Id }, aspnetusers);
        }

        // DELETE: api/AspNetUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.AspNetUsers>> DeleteAspNetUsers(int id)
        {
            var aspnetusers = new Solution.BS.AspNetUsers(_context).GetOneById(id);
            if (aspnetusers == null)
            {
                return NotFound();
            }

            new Solution.BS.AspNetUsers(_context).Delete(aspnetusers);
            var mapaux = _mapper.Map<data.AspNetUsers, datamodels.AspNetUsers>(aspnetusers);

            return mapaux;
        }

        private bool AspNetUsersExists(int id)
        {
            return (new Solution.BS.AspNetUsers(_context).GetOneById(id) != null);
        }
        
    }
}
