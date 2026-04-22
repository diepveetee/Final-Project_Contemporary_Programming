namespace TeamApi.Models
{
    public class FavoriteVideoGame
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public int HoursPlayed { get; set; }
    }
}
