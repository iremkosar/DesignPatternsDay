using DesignPatternsDay.Entities;

namespace DesignPatternsDay.Patterns.Chain
{
    public class PriceValidationHandler:ValidationHandler
    {
        public override string Handle(object request)
        {
            var product = (Product)request;

            if (product.Price <= 0)
                return "Fiyat 0'dan büyük olmalı.";

            return base.Handle(request);
        }
    }
}
