namespace DesignPatternsDay.Patterns.Decorator
{
    public interface IProductDecorator
    {
        decimal GetPrice();
        string GetDescription();
    }
}