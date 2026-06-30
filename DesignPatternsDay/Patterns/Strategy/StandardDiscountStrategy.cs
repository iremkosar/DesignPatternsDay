namespace DesignPatternsDay.Patterns.Strategy
{
    public class StandardDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price) => price * 0.95m;
        public string GetDescription() => "Standart indirim (%5)";
    }
}