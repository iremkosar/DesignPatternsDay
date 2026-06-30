using DesignPatternsDay.Entities;

namespace DesignPatternsDay.Patterns.Chain
{
    public class StockValidationHandler:ValidationHandler
    {
        public override string Handle(object request)
        {
            var product = (Product)request;

            if (product.Stock < 0)
                return "Stok negatif olamaz";

            return base.Handle(request);
        }
    }
}
