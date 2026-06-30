using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDay.Controllers.Admin
{
    public class AboutUsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AboutUsController(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public IActionResult Index()
        {
            var item = _unitOfWork.GetRepository<AboutUs>().GetAll().FirstOrDefault();
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            var item = _unitOfWork.GetRepository<AboutUs>().GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(AboutUs aboutUs)
        {
            _unitOfWork.GetRepository<AboutUs>().Update(aboutUs);
            _unitOfWork.Commit();
            TempData["Success"] = "Hakkımızda güncellendi.";
            return RedirectToAction("Index");
        }
    }
}