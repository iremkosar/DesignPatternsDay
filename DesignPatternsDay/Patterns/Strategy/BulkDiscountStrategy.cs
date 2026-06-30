namespace DesignPatternsDay.Patterns.Strategy
{
    public class BulkDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price) => price * 0.85m;
        public string GetDescription() => "Toplu alım indirimi (%15)";
    }
}

