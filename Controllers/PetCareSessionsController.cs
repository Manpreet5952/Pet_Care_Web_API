using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_Care_Web_API.Model;
using Pet_Care_Web_API.Models;

namespace Pet_Care_Web_API.Controllers
{
    //Api controller for pet care
    [Route("api/[controller]")]
    [ApiController]
    public class PetCareSessionsController : ControllerBase
    {
        private readonly Pet_Care_Web_APIContext _context;

        public PetCareSessionsController(Pet_Care_Web_APIContext context)
        {
            _context = context;
        }

        // GET: api/PetCareSessions
        //Get all pet care sessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetCareSession>>> GetPetCareSession()
        {
            return await (from petcare in _context.PetCareSession select petcare).ToListAsync();
        }

        // GET: api/PetCareSessions/5
        //Get pet care details
        [HttpGet("{id}")]
        public async Task<ActionResult<PetCareSession>> GetPetCareSession(int id)
        {
            var petCareSession = await _context.PetCareSession.FindAsync(id);

            if (petCareSession == null)
            {
                return NotFound();
            }

            return petCareSession;
        }

        // PUT: api/PetCareSessions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Update pet care details.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetCareSession(int id, PetCareSession petCareSession)
        {
            if (id != petCareSession.Id)
            {
                return BadRequest();
            }

            _context.Entry(petCareSession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetCareSessionExists(id))
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

        // POST: api/PetCareSessions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Add pet care session
        [HttpPost]
        public async Task<ActionResult<PetCareSession>> PostPetCareSession(PetCareSession petCareSession)
        {
            _context.PetCareSession.Add(petCareSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetCareSession", new { id = petCareSession.Id }, petCareSession);
        }

        // DELETE: api/PetCareSessions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PetCareSession>> DeletePetCareSession(int id)
        {
            var petCareSession = await _context.PetCareSession.FindAsync(id);
            if (petCareSession == null)
            {
                return NotFound();
            }

            _context.PetCareSession.Remove(petCareSession);
            await _context.SaveChangesAsync();

            return petCareSession;
        }

        //Check pet care session exists using lamda 
        private bool PetCareSessionExists(int id)
        {
            return _context.PetCareSession.Any(e => e.Id == id);
        }
    }
}
