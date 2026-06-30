using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DesignPatternsDay.Controllers
{
    public class CompareController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompareController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private List<int> GetCompareList()
        {
            var json = HttpContext.Session.GetString("Compare");
            return json == null ? new List<int>() : JsonSerializer.Deserialize<List<int>>(json);
        }

        private void SaveCompareList(List<int> ids)
        {
            HttpContext.Session.SetString("Compare", JsonSerializer.Serialize(ids));
        }

        public IActionResult Index()
        {
            var ids = GetCompareList();
            var products = ids
                .Select(id => _unitOfWork.GetRepository<Product>().GetById(id))
                .Where(p => p != null)
                .ToList();

            return View(products);
        }

        [HttpPost]
        public IActionResult AddToCompare(int productId)
        {
            var ids = GetCompareList();

            if (ids.Count >= 4)
            {
                TempData["Error"] = "En fazla 4 ürün karşılaştırabilirsiniz.";
                return RedirectToAction("Index", "Shop");
            }

            if (!ids.Contains(productId))
                ids.Add(productId);

            SaveCompareList(ids);
            TempData["Success"] = "Ürün karşılaştırmaya eklendi.";
            return RedirectToAction("Index", "Shop");
        }

        public IActionResult Remove(int productId)
        {
            var ids = GetCompareList();
            ids.Remove(productId);
            SaveCompareList(ids);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Compare");
            return RedirectToAction("Index");
        }
    }
}