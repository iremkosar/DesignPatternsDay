using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDay.Controllers.Admin
{
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceController(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public IActionResult Index()
        {
            return View(_unitOfWork.GetRepository<Service>().GetAll());
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Service service)
        {
            _unitOfWork.GetRepository<Service>().Add(service);
            _unitOfWork.Commit();
            TempData["Success"] = "Servis eklendi.";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var item = _unitOfWork.GetRepository<Service>().GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Service service)
        {
            _unitOfWork.GetRepository<Service>().Update(service);
            _unitOfWork.Commit();
            TempData["Success"] = "Servis güncellendi.";
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.GetRepository<Service>().Delete(id);
            _unitOfWork.Commit();
            TempData["Success"] = "Servis silindi.";
            return RedirectToAction("Index");
        }
    }
}