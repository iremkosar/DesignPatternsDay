using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDay.Controllers.Admin
{
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogController(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public IActionResult Index()
        {
            return View(_unitOfWork.GetRepository<Blog>().GetAll());
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            _unitOfWork.GetRepository<Blog>().Add(blog);
            _unitOfWork.Commit();
            TempData["Success"] = "Blog yazısı eklendi.";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var item = _unitOfWork.GetRepository<Blog>().GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            _unitOfWork.GetRepository<Blog>().Update(blog);
            _unitOfWork.Commit();
            TempData["Success"] = "Blog yazısı güncellendi.";
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.GetRepository<Blog>().Delete(id);
            _unitOfWork.Commit();
            TempData["Success"] = "Blog yazısı silindi.";
            return RedirectToAction("Index");
        }
    }
}