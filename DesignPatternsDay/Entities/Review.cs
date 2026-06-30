namespace DesignPatternsDay.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string? Title { get; set; }
        public string Comment { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsApproved { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}