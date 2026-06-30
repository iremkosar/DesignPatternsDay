using DesignPatternsDay.Entities;

namespace DesignPatternsDay.Patterns.Chain
{
    public class NameValidationHandler:ValidationHandler
    {
        public override string Handle(object request)
        {
            var product = (Product)request;

            if (string.IsNullOrEmpty(product.Name))
                return "Ürün Adı Boş Olamaz";
            if (product.Name.Length < 3)
                return "Ürün adı en az üç karakter olmalı.";

            return base.Handle(request); //bir sonraki halkaya geç
        }
    }
}
