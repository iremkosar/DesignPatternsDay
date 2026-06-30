using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDay.Controllers.Admin
{
    public class BannerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BannerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var banners = _unitOfWork.GetRepository<Banner>().GetAll();
            return View(banners);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Banner banner)
        {
            _unitOfWork.GetRepository<Banner>().Add(banner);
            _unitOfWork.Commit();
            TempData["Success"] = "Banner başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var banner = _unitOfWork.GetRepository<Banner>().GetById(id);
            if (banner == null) return NotFound();
            return View(banner);
        }

        [HttpPost]
        public IActionResult Edit(Banner banner)
        {
            _unitOfWork.GetRepository<Banner>().Update(banner);
            _unitOfWork.Commit();
            TempData["Success"] = "Banner başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.GetRepository<Banner>().Delete(id);
            _unitOfWork.Commit();
            TempData["Success"] = "Banner başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}