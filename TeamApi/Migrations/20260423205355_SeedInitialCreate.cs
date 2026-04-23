using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FavoriteFoods",
                columns: new[] { "Id", "ContinentOrigin", "FoodName", "IsHot", "IsVegetarian" },
                values: new object[,]
                {
                    { 1, "North America", "Fried Chicken", true, false },
                    { 2, "Asia", "Yogurt", false, true },
                    { 3, "North America", "CheeseBurger", true, false },
                    { 4, "Europe", "Fettaccine Alfredo", true, false }
                });

            migrationBuilder.InsertData(
                table: "FavoriteVideoGames",
                columns: new[] { "Id", "Genre", "HoursPlayed", "Platform", "Title" },
                values: new object[,]
                {
                    { 1, "Turn-Based RPG", 895, "Desktop", "Baldurs Gate 3" },
                    { 2, "Strategy", 700, "Desktop", "Rollercoaster Tycoon 2" },
                    { 3, "Dungeon Crawler, Roguelite", 2, "Desktop", "Sol cesto" },
                    { 4, "FPS", 1153, "Desktop", "MechWarrior Online" }
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Description", "Name", "WeeklyHours", "YearsDoingIt" },
                values: new object[,]
                {
                    { 1, "Playing video games with friends.", "Video Games", 14, 16 },
                    { 2, "Lifting weights", "Weightlifting", 5, 6 },
                    { 3, "Reading Manga", "Manga", 24, 4 },
                    { 4, "Cooking meals for myself and others.", "Cooking", 9, 8 }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "BirthDate", "CollegeProgram", "FullName", "YearInProgram" },
                values: new object[,]
                {
                    { 1, new DateTime(2004, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology, Systems Adminstration and Game Design", "Gabriel Boehm", "Third Year, Junior" },
                    { 2, new DateTime(2001, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT Software Development", "Van Diep", "Second Year, Sophmore" },
                    { 3, new DateTime(2002, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT Software Development", "Jane Doe", "First Year, Freshman" },
                    { 4, new DateTime(2005, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trade School", "Adrian Taveras", "Second Year, Sophmore" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FavoriteFoods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FavoriteFoods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FavoriteFoods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FavoriteFoods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FavoriteVideoGames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FavoriteVideoGames",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FavoriteVideoGames",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FavoriteVideoGames",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
