namespace DesignPatternsDay.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? IconUrl { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; } = true;
    }
}