namespace DesignPatternsDay.Patterns.Decorator
{
    public class BaseProduct : IProductDecorator
    {
        private readonly decimal _price;
        private readonly string _name;

        public BaseProduct(decimal price, string name)
        {
            _price = price;
            _name = name;
        }

        public decimal GetPrice() => _price;
        public string GetDescription() => _name;
    }
}