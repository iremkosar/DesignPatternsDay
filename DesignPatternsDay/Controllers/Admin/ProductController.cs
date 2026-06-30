using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.Chain;
using DesignPatternsDay.Patterns.Decorator;
using DesignPatternsDay.Patterns.Observer;
using DesignPatternsDay.Patterns.Strategy;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDay.Controllers.Admin
{    
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductObservable _observable;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _observable = new ProductObservable();
            _observable.Subscribe(new StockObserver());
        }

        
        public IActionResult Index()
        {
            var products = _unitOfWork.GetRepository<Product>().GetAll();
            return View(products);
        }

      
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Product product, string discountType, IFormFile? imageFile)
        {
            // Chain of Responsibility
            var nameHandler = new NameValidationHandler();
            var priceHandler = new PriceValidationHandler();
            var stockHandler = new StockValidationHandler();
            nameHandler.SetNext(priceHandler).SetNext(stockHandler);

            var error = nameHandler.Handle(product);
            if (error != null)
            {
                TempData["Error"] = error;
                return View(product);
            }

           

            // Strategy
            IDiscountStrategy strategy = discountType switch
            {
                "bulk" => new BulkDiscountStrategy(),
                "seasonal" => new SeasonalDiscountStrategy(),
                _ => new StandardDiscountStrategy()
            };
            product.Price = strategy.ApplyDiscount(product.Price);

            // Decorator
            IProductDecorator decorator = new BaseProduct(product.Price, product.Name);
            decorator = new VatDecorator(decorator);
            product.Price = decorator.GetPrice();

            _unitOfWork.GetRepository<Product>().Add(product);
            _unitOfWork.Commit();

            _observable.CheckStock(product.Name, product.Stock);

            TempData["Success"] = "Ürün başarıyla eklendi.";
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var product = _unitOfWork.GetRepository<Product>().GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }


        [HttpPost]
        public IActionResult Edit(Product product, IFormFile? imageFile)
        {
            var nameHandler = new NameValidationHandler();
            var priceHandler = new PriceValidationHandler();
            var stockHandler = new StockValidationHandler();
            nameHandler.SetNext(priceHandler).SetNext(stockHandler);

            var error = nameHandler.Handle(product);
            if (error != null)
            {
                TempData["Error"] = error;
                return View(product);
            }

     

            _unitOfWork.GetRepository<Product>().Update(product);
            _unitOfWork.Commit();

            _observable.CheckStock(product.Name, product.Stock);

            TempData["Success"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.GetRepository<Product>().GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

      
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.GetRepository<Product>().Delete(id);
            _unitOfWork.Commit();

            TempData["Success"] = "Ürün başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}