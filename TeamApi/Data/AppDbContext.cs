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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember
                {
                    Id = 1,
                    FullName = "Gabriel Boehm",
                    BirthDate = new DateTime(2004, 10, 21),
                    CollegeProgram = "Information Technology, Systems Adminstration and Game Design",
                    YearInProgram = "Third Year, Junior"
                }, 
                new TeamMember
                {
                    Id = 2,
                    FullName = "Van Diep",
                    BirthDate = new DateTime(2001, 01, 30),
                    CollegeProgram = "IT Software Development",
                    YearInProgram = "Second Year, Sophmore"
                },
                new TeamMember
                {
                    Id = 3,
                    FullName = "Jane Doe",
                    BirthDate = new DateTime(2002, 03, 20),
                    CollegeProgram = "IT Software Development",
                    YearInProgram = "First Year, Freshman"
                },
                new TeamMember
                {
                    Id = 4,
                    FullName = "Adrian Taveras",
                    BirthDate = new DateTime(2005, 01, 04),
                    CollegeProgram = "Trade School",
                    YearInProgram = "Second Year, Sophmore"
                }
                );
            modelBuilder.Entity<FavoriteVideoGame>().HasData(
                new FavoriteVideoGame
                {
                    Id = 1,
                    Title = "Baldurs Gate 3",
                    Genre = "Turn-Based RPG",
                    Platform = "Desktop",
                    HoursPlayed = 895
                },
                new FavoriteVideoGame
                {
                    Id = 2,
                    Title = "Rollercoaster Tycoon 2",
                    Genre = "Strategy",
                    Platform = "Desktop",
                    HoursPlayed = 700
                },
                new FavoriteVideoGame
                {
                    Id = 3,
                    Title = "Sol cesto",
                    Genre = "Dungeon Crawler, Roguelite",
                    Platform = "Desktop",
                    HoursPlayed = 2
                },
                new FavoriteVideoGame
                {
                    Id = 4,
                    Title = "MechWarrior Online",
                    Genre = "FPS",
                    Platform = "Desktop",
                    HoursPlayed = 1153
                });
                
            modelBuilder.Entity<FavoriteFood>().HasData(
                new FavoriteFood
                {
                    Id = 1,
                    FoodName = "Fried Chicken",
                    ContinentOrigin = "North America",
                    IsHot = true,
                    IsVegetarian = false

                },
                new FavoriteFood
                {
                    Id = 2,
                    FoodName = "Yogurt",
                    ContinentOrigin = "Asia",
                    IsHot = false,
                    IsVegetarian = true

                },
                new FavoriteFood
                {
                    Id = 3,
                    FoodName = "CheeseBurger",
                    ContinentOrigin = "North America",
                    IsHot = true,
                    IsVegetarian = false

                },
                new FavoriteFood
                {
                    Id = 4,
                    FoodName = "Fettaccine Alfredo",
                    ContinentOrigin = "Europe",
                    IsHot = true,
                    IsVegetarian = false

                });
            modelBuilder.Entity<Hobby>().HasData(
                new Hobby
                {
                    Id = 1,
                    Name = "Video Games",
                    Description = "Playing video games with friends.",
                    YearsDoingIt = 16,
                    WeeklyHours = 14

                },
                new Hobby
                {
                    Id = 2,
                    Name = "Weightlifting",
                    Description = "Lifting weights",
                    YearsDoingIt = 6,
                    WeeklyHours = 5

                },
                new Hobby
                {
                    Id = 3,
                    Name = "Manga",
                    Description = "Reading Manga",
                    YearsDoingIt = 4,
                    WeeklyHours = 24

                },
                 new Hobby
                 {
                     Id = 4,
                     Name = "Cooking",
                     Description = "Cooking meals for myself and others.",
                     YearsDoingIt = 8,
                     WeeklyHours = 9

                 });
        }
    }
}
