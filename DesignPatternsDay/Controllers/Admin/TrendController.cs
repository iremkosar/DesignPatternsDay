using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDay.Controllers.Admin
{
    public class TrendController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrendController(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public IActionResult Index()
        {
            return View(_unitOfWork.GetRepository<Trend>().GetAll());
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Trend trend)
        {
            _unitOfWork.GetRepository<Trend>().Add(trend);
            _unitOfWork.Commit();
            TempData["Success"] = "Trend eklendi.";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var item = _unitOfWork.GetRepository<Trend>().GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Trend trend)
        {
            _unitOfWork.GetRepository<Trend>().Update(trend);
            _unitOfWork.Commit();
            TempData["Success"] = "Trend güncellendi.";
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.GetRepository<Trend>().Delete(id);
            _unitOfWork.Commit();
            TempData["Success"] = "Trend silindi.";
            return RedirectToAction("Index");
        }
    }
}