using DesignPatternsDay.Entities;
using DesignPatternsDay.Patterns.Decorator;
using DesignPatternsDay.Patterns.Strategy;
using DesignPatternsDay.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DesignPatternsDay.Controllers
{
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Session'dan sepeti oku
        private List<CartItem> GetCart()
        {
            var json = HttpContext.Session.GetString("Cart");
            return json == null ? new List<CartItem>() : JsonSerializer.Deserialize<List<CartItem>>(json);
        }

        // Session'a sepeti kaydet
        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
        }

        // Sepeti göster — Strategy + Decorator burada devreye giriyor
        public IActionResult Index(string discountType = "standard")
        {
            var cart = GetCart();

            // Strategy Pattern — hangi indirim stratejisi?
            IDiscountStrategy strategy = discountType switch
            {
                "bulk" => new BulkDiscountStrategy(),
                "seasonal" => new SeasonalDiscountStrategy(),
                _ => new StandardDiscountStrategy()
            };

            // Her ürüne strateji uygula
            decimal subtotal = 0;
            foreach (var item in cart)
            {
                var discountedPrice = strategy.ApplyDiscount(item.Price);
                subtotal += discountedPrice * item.Quantity;
            }

            // Decorator Pattern — subtotal'a KDV ekle
            IProductDecorator decorator = new BaseProduct(subtotal, "Sepet Toplamı");
            decorator = new VatDecorator(decorator);
            decimal total = decorator.GetPrice();

            ViewBag.Cart = cart;
            ViewBag.Subtotal = subtotal;
            ViewBag.Total = total;
            ViewBag.StrategyDesc = strategy.GetDescription();
            ViewBag.CurrentDiscount = discountType;

            return View(cart);
        }

        // Sepete ürün ekle — Observer Pattern burada tetiklenebilir
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var product = _unitOfWork.GetRepository<Product>().GetById(productId);
            if (product == null) return NotFound();

            var cart = GetCart();
            var existing = cart.FirstOrDefault(x => x.ProductId == productId);

            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity,
                    ImageUrl = product.ImageUrl
                });
            }

            SaveCart(cart);
            TempData["Success"] = $"{product.Name} sepete eklendi.";
            return RedirectToAction("Index");
        }

        // Sepetten ürün sil
        public IActionResult Remove(int productId)
        {
            var cart = GetCart();
            cart.RemoveAll(x => x.ProductId == productId);
            SaveCart(cart);
            return RedirectToAction("Index");
        }

        // Sepeti temizle
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Increase(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.ProductId == id);
            if (item != null) item.Quantity++;
            SaveCart(cart);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Decrease(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.ProductId == id);
            if (item != null)
            {
                if (item.Quantity > 1) item.Quantity--;
                else cart.Remove(item);
            }
            SaveCart(cart);
            return RedirectToAction("Index");
        }
    }
}