using Microsoft.AspNetCore.Mvc;
using TeamApi.Data;
using TeamApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TeamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteVideoGameController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoriteVideoGameController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
            {
                var favoriteVideoGames = await _context.FavoriteVideoGames.Take(5).ToListAsync();
                return Ok(favoriteVideoGames);
            }

            var favoriteVideoGame = await _context.FavoriteVideoGames.FindAsync(id);
            if (favoriteVideoGame == null)
            {
                return NotFound("Favorite video game not found");
            }
            return Ok(favoriteVideoGame);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FavoriteVideoGame favoriteVideoGame)
        {
            if (favoriteVideoGame == null)
            {
                return BadRequest("Invalid favorite video game data");
            }

            _context.FavoriteVideoGames.Add(favoriteVideoGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = favoriteVideoGame.Id }, favoriteVideoGame);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FavoriteVideoGame updatedFavoriteVideoGame)
        {
            if (updatedFavoriteVideoGame == null || updatedFavoriteVideoGame.Id != id)
            {
                return BadRequest("Invalid favorite video game data");
            }

            var existingFavoriteVideoGame = await _context.FavoriteVideoGames.FindAsync(id);
            if (existingFavoriteVideoGame == null)
            {
                return NotFound("Favorite video game not found");
            }

            existingFavoriteVideoGame.Title = updatedFavoriteVideoGame.Title;
            existingFavoriteVideoGame.Genre = updatedFavoriteVideoGame.Genre;
            existingFavoriteVideoGame.Platform = updatedFavoriteVideoGame.Platform;
            existingFavoriteVideoGame.HoursPlayed = updatedFavoriteVideoGame.HoursPlayed;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "An error occurred while updating the favorite video game");
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var favoriteVideoGame = await _context.FavoriteVideoGames.FindAsync(id);
            if (favoriteVideoGame == null)
            {
                return NotFound("Favorite video game not found");
            }
            _context.FavoriteVideoGames.Remove(favoriteVideoGame);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
