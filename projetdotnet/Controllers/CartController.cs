using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetdotnet.Models;
using projetdotnet.Repository;
using projetdotnet.Repository.IRepository;
using System.Security.Claims;

namespace projetdotnet.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartVM ShoppingCartVM { get; set; }

        public CartController(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public IActionResult Index()
        {
            try
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                ShoppingCartVM = new()
                {
                    ShoppingCartList = _shoppingCartRepository.GetAllCart(
                        cart => cart.ApplicationUserId == userId, // Corrected the filter
                        includeProperties: "Product"
                    )
                };
                foreach(var cart in ShoppingCartVM.ShoppingCartList)
                {
                    cart.price = GetPriceBasedOnQuantity( cart );
                    ShoppingCartVM.OrderTotal += (cart.price * cart.Count);
                }

                return View(ShoppingCartVM);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                return View("Error");
            }
        }
        public IActionResult Delete(int cartId) {
            var cartFromDb = _shoppingCartRepository.Get(u => u.Id == cartId);
            _shoppingCartRepository.Remove(cartFromDb);
            _shoppingCartRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private double GetPriceBasedOnQuantity(shoppingCart shoppingCart)
        {
            if(shoppingCart.Count <= 50)
            {
                return shoppingCart.Product.Price;
            }
            else
            {
                if(shoppingCart.Count <= 100)
                {
                    return shoppingCart.Product.Price50;
                }
                else
                {
                    return shoppingCart.Product.Price100;
                }
            }
           
        }

    }
}
