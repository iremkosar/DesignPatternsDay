namespace DesignPatternsDay.Patterns.Decorator
{
    public class VatDecorator : IProductDecorator
    {
        private readonly IProductDecorator _inner;

        public VatDecorator(IProductDecorator inner)
        {
            _inner = inner;
        }

        public decimal GetPrice() => _inner.GetPrice() * 1.18m;
        public string GetDescription() => _inner.GetDescription() + " + KDV(%18)";
    }
}