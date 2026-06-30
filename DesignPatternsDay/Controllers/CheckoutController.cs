using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DesignPatternsDay.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckoutController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private List<CartItem> GetCart()
        {
            var json = HttpContext.Session.GetString("Cart");
            return json == null ? new List<CartItem>() : JsonSerializer.Deserialize<List<CartItem>>(json);
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            if (!cart.Any()) return RedirectToAction("Index", "Cart");
            ViewBag.Cart = cart;
            ViewBag.Total = cart.Sum(c => c.Price * c.Quantity);
            return View();
        }

        [HttpPost]
        public IActionResult PlaceOrder(string customerName, string customerEmail, string customerPhone, string address)
        {
            var cart = GetCart();
            if (!cart.Any()) return RedirectToAction("Index", "Cart");

            var order = new Order
            {
                CustomerName = customerName,
                CustomerEmail = customerEmail,
                CustomerPhone = customerPhone,
                Address = address,
                TotalPrice = cart.Sum(c => c.Price * c.Quantity),
                Status = "Beklemede",
                CreatedAt = DateTime.Now,
                OrderItems = cart.Select(c => new OrderItem
                {
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    Price = c.Price,
                    Quantity = c.Quantity
                }).ToList()
            };

            _unitOfWork.GetRepository<Order>().Add(order);
            _unitOfWork.Commit();

            HttpContext.Session.Remove("Cart");

            TempData["Success"] = "Siparişiniz başarıyla alındı!";
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}