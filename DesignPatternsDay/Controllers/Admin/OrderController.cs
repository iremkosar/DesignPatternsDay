using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDay.Controllers.Admin
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public IActionResult Index()
        {
            var orders = _unitOfWork.GetRepository<Order>().GetAll()
                .OrderByDescending(o => o.CreatedAt).ToList();
            return View(orders);
        }

        public IActionResult Detail(int id)
        {
            var order = _unitOfWork.GetRepository<Order>().GetById(id);
            if (order == null) return NotFound();
            var orderItems = _unitOfWork.GetRepository<OrderItem>().GetAll()
                .Where(oi => oi.OrderId == id).ToList();
            ViewBag.OrderItems = orderItems;
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            var order = _unitOfWork.GetRepository<Order>().GetById(id);
            if (order == null) return NotFound();
            order.Status = status;
            _unitOfWork.GetRepository<Order>().Update(order);
            _unitOfWork.Commit();
            TempData["Success"] = "Sipariş durumu güncellendi.";
            return RedirectToAction("Detail", new { id });
        }
    }
}