namespace TeamApi.Models
{
    public class FavoriteFood
    {
        public int Id { get; set; }
        public string FoodName { get; set; } = string.Empty;
        public string ContinentOrigin { get; set; } = string.Empty;
        public bool IsHot { get; set; }
        public bool IsVegetarian { get; set; }
    }
}
