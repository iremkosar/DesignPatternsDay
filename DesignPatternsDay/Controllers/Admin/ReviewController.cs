using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDay.Controllers.Admin
{
    public class ReviewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReviewController(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public IActionResult Index()
        {
            return View(_unitOfWork.GetRepository<Review>().GetAll()
                .OrderByDescending(r => r.CreatedAt).ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Review review)
        {
            review.IsApproved = true;
            _unitOfWork.GetRepository<Review>().Add(review);
            _unitOfWork.Commit();
            TempData["Success"] = "Yorum eklendi.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Approve(int id)
        {
            var review = _unitOfWork.GetRepository<Review>().GetById(id);
            if (review == null) return NotFound();
            review.IsApproved = true;
            _unitOfWork.GetRepository<Review>().Update(review);
            _unitOfWork.Commit();
            TempData["Success"] = "Yorum onaylandı.";
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.GetRepository<Review>().Delete(id);
            _unitOfWork.Commit();
            TempData["Success"] = "Yorum silindi.";
            return RedirectToAction("Index");
        }
    }
}