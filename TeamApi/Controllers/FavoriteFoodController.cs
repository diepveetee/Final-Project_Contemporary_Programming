using Microsoft.AspNetCore.Mvc;
using TeamApi.Data;
using TeamApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TeamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteFoodController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoriteFoodController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
            {
                var favoriteFoods = await _context.FavoriteFoods.Take(5).ToListAsync();
                return Ok(favoriteFoods);
            }

            var favoriteFood = await _context.FavoriteFoods.FindAsync(id);
            if (favoriteFood == null)
            {
                return NotFound("Favorite food not found");
            }
            return Ok(favoriteFood);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FavoriteFood favoriteFood)
        {
            if (favoriteFood == null)
            {
                return BadRequest("Invalid favorite food data");
            }

            _context.FavoriteFoods.Add(favoriteFood);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = favoriteFood.Id }, favoriteFood);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FavoriteFood updatedFavoriteFood)
        {
            if (updatedFavoriteFood == null || updatedFavoriteFood.Id != id)
            {
                return BadRequest("Invalid favorite food data");
            }

            var existingFavoriteFood = await _context.FavoriteFoods.FindAsync(id);
            if (existingFavoriteFood == null)
            {
                return NotFound("Favorite food not found");
            }

            existingFavoriteFood.FoodName = updatedFavoriteFood.FoodName;
            existingFavoriteFood.ContinentOrigin = updatedFavoriteFood.ContinentOrigin;
            existingFavoriteFood.IsHot = updatedFavoriteFood.IsHot;
            existingFavoriteFood.IsVegetarian = updatedFavoriteFood.IsVegetarian;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "An error occurred while updating the favorite food");
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var favoriteFood = await _context.FavoriteFoods.FindAsync(id);
            if (favoriteFood == null)
            {
                return NotFound("Favorite food not found");
            }
            _context.FavoriteFoods.Remove(favoriteFood);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
