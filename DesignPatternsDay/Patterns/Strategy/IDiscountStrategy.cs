namespace DesignPatternsDay.Patterns.Strategy
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal price);
        string GetDescription();
    }
}
