using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.Strategy;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDay.Controllers
{
    public class ShopController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string category, string sort)
        {
            var products = _unitOfWork.GetRepository<Product>().GetAll();

            // Category filter
            if (!string.IsNullOrEmpty(category))
                products = products.Where(p => p.Category == category).ToList();

            var trendingProducts = _unitOfWork.GetRepository<Product>().GetAll()
    .Where(p => p.Stock > 0)
    .Take(5)
    .ToList();
            ViewBag.TrendingProducts = trendingProducts;

            // Strategy Pattern - sıralama
            IDiscountStrategy strategy = sort switch
            {
                "bulk" => new BulkDiscountStrategy(),
                "seasonal" => new SeasonalDiscountStrategy(),
                _ => new StandardDiscountStrategy()
            };

            ViewBag.Categories = products.Select(p => p.Category).Distinct().ToList();
            ViewBag.CurrentCategory = category;
            ViewBag.CurrentSort = sort;
            ViewBag.Strategy = strategy.GetDescription();        

            return View(products);
        }
    }
}