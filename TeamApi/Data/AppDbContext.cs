using Microsoft.EntityFrameworkCore;
using TeamApi.Models;
using TeamApi.Data;


namespace TeamApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<FavoriteFood> FavoriteFoods { get; set; }
        public DbSet<FavoriteVideoGame> FavoriteVideoGames { get; set; }
    }
}
