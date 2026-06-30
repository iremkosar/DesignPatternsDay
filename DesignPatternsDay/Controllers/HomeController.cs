using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDay.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var products = _unitOfWork.GetRepository<Product>().GetAll();

            // Banner
            var banner = _unitOfWork.GetRepository<Banner>().GetAll().FirstOrDefault(b => b.IsActive);
            ViewBag.Banner = banner;

            var services = _unitOfWork.GetRepository<Service>().GetAll().Where(s => s.IsActive).OrderBy(s => s.OrderNo).ToList();
            ViewBag.Services = services;

            var trends = _unitOfWork.GetRepository<Trend>().GetAll().Where(t => t.IsActive).OrderBy(t => t.OrderNo).ToList();
            ViewBag.Trends = trends;

            var allProducts = _unitOfWork.GetRepository<Product>().GetAll().Where(p => p.Stock > 0).ToList();
            ViewBag.MainDishes = allProducts.Where(p => p.Category == "Vegetables" || p.Category == "Meats").Take(9).ToList();
            ViewBag.Starters = allProducts.Where(p => p.Category == "Fruits").Take(9).ToList();
            ViewBag.Drinks = allProducts.Where(p => p.Category == "Beverages").Take(9).ToList();

            var blogs = _unitOfWork.GetRepository<Blog>().GetAll()
            .Where(b => b.IsActive)
            .OrderByDescending(b => b.CreatedAt)
            .Take(4)
            .ToList();
            ViewBag.Blogs = blogs;

            var reviews = _unitOfWork.GetRepository<Review>().GetAll()
            .Where(r => r.IsApproved)
            .Take(5).
            ToList();
            ViewBag.Reviews = reviews;

            var latestProducts = _unitOfWork.GetRepository<Product>().GetAll()
    .Where(p => p.Stock > 0)
    .OrderByDescending(p => p.CreatedAt)
    .Take(4)
    .ToList();
            ViewBag.LatestProducts = latestProducts;

            return View(products);
        }
    }
}