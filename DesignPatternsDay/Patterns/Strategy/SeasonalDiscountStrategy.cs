namespace DesignPatternsDay.Patterns.Strategy
{
    public class SeasonalDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price) => price * 0.90m;
        public string GetDescription() => "Mevsimsel indirim (%10)";
    }
}