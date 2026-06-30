using DesignPatternsDay.Patterns.Decorator;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDay.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int id)
        {
            var product = _unitOfWork.GetRepository<DesignPatternsDay.Entities.Product>().GetById(id);
            if (product == null) return NotFound();

            // Decorator Pattern — ürün fiyatına KDV ekle
            IProductDecorator decorator = new BaseProduct(product.Price, product.Name);
            decorator = new VatDecorator(decorator);

            ViewBag.PriceWithVat = decorator.GetPrice();
            ViewBag.VatDescription = decorator.GetDescription();

            return View(product);
        }
    }
}