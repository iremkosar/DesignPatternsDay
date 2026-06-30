namespace DesignPatternsDay.Entities
{
    public class Trend
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? LinkUrl { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; } = true;
    }
}