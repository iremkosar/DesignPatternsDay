using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDay.Controllers.Admin
{
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrandController(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public IActionResult Index()
        {
            return View(_unitOfWork.GetRepository<Brand>().GetAll());
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            _unitOfWork.GetRepository<Brand>().Add(brand);
            _unitOfWork.Commit();
            TempData["Success"] = "Marka eklendi.";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var item = _unitOfWork.GetRepository<Brand>().GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            _unitOfWork.GetRepository<Brand>().Update(brand);
            _unitOfWork.Commit();
            TempData["Success"] = "Marka güncellendi.";
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.GetRepository<Brand>().Delete(id);
            _unitOfWork.Commit();
            TempData["Success"] = "Marka silindi.";
            return RedirectToAction("Index");
        }
    }
}