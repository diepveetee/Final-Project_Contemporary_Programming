using Microsoft.AspNetCore.Mvc;
using TeamApi.Data;
using TeamApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TeamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HobbyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
            {
                var hobbies = await _context.Hobbies.Take(5).ToListAsync();
                return Ok(hobbies);
            }

            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null)
            {
                return NotFound("Hobby not found");
            }
            return Ok(hobby);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Hobby hobby)
        {
            if (hobby == null)
            {
                return BadRequest("Invalid hobby data");
            }

            _context.Hobbies.Add(hobby);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = hobby.Id }, hobby);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Hobby updatedHobby)
        {
            if (updatedHobby == null || updatedHobby.Id != id)
            {
                return BadRequest("Hobby game data");
            }

            var existingHobby = await _context.Hobbies.FindAsync(id);
            if (existingHobby == null)
            {
                return NotFound("Hobby not found");
            }

            existingHobby.Name = updatedHobby.Name;
            existingHobby.Description = updatedHobby.Description;
            existingHobby.YearsDoingIt = updatedHobby.YearsDoingIt;
            existingHobby.WeeklyHours = updatedHobby.WeeklyHours;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "An error occurred while updating hobby");
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null)
            {
                return NotFound("Hobby not found");
            }
            _context.Hobbies.Remove(hobby);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
