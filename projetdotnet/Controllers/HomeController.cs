using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projetdotnet.Models;
using projetdotnet.Repository;
using projetdotnet.Repository.IRepository;
using System.Diagnostics;
using System.Security.Claims;

namespace projetdotnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private  readonly ICategoryRepository _CategoryRepo;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public HomeController(ILogger<HomeController> logger,IProductRepository productRepository,ICategoryRepository categoryRepository , IShoppingCartRepository shoppingCartRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _CategoryRepo = categoryRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> ProductList = _productRepository.GetAll();
            return View(ProductList);
        }
        public IActionResult Details(int productId)
        {
            shoppingCart cart = new()
            {
                Product = _productRepository.Get(filter: u => u.Id == productId),
                Count = 1,
                ProductId = productId
        };
           
            // Fetch the list of categories from the repository
            IEnumerable<Category> categories = _CategoryRepo.GetAll();

            // Convert the list of categories to SelectListItems
            IEnumerable<SelectListItem> categoryList = categories
                .Select(category => new SelectListItem
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.Name
                })
                .ToList();

            // Pass the categoryList to the view
            ViewBag.CategoryList = categoryList;
            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(shoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;
            shoppingCart cartFromDb = _shoppingCartRepository.Get(u=>u.ApplicationUserId==userId &&
            u.ProductId == shoppingCart.ProductId);
            if (cartFromDb != null) {
                //exist
                cartFromDb.Count += shoppingCart.Count;
                _shoppingCartRepository.Update(cartFromDb);
            }
            else
            {
                //add cart 
                _shoppingCartRepository.Add(shoppingCart);   
            }
          
            _shoppingCartRepository.Save();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}