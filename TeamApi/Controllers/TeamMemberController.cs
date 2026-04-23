using Microsoft.AspNetCore.Mvc;
using TeamApi.Data;
using TeamApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TeamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamMemberController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
            {
                var teamMembers = await _context.TeamMembers.Take(5).ToListAsync();
                return Ok(teamMembers);
            }

            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember == null)
            {
                return NotFound("Member not found");
            }
            return Ok(teamMember);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TeamMember teamMember)
        {
            if (teamMember == null)
            {
                return BadRequest("Invalid team member data");
            }

            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = teamMember.Id }, teamMember);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TeamMember updatedTeamMember)
        {
            if (updatedTeamMember == null || updatedTeamMember.Id != id)
            {
                return BadRequest("Invalid team member data");
            }

            var existingTeamMember = await _context.TeamMembers.FindAsync(id);
            if (existingTeamMember == null)
            {
                return NotFound("Team member not found");
            }

            existingTeamMember.FullName = existingTeamMember.FullName;
            existingTeamMember.BirthDate = existingTeamMember.BirthDate;
            existingTeamMember.CollegeProgram = existingTeamMember.CollegeProgram;
            existingTeamMember.YearInProgram = existingTeamMember.YearInProgram;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "An error occurred while updating the team member");
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember == null)
            {
                return NotFound("Member not found");
            }
            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
