using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projetdotnet.Models;
using projetdotnet.Repository;
using projetdotnet.Repository.IRepository;

namespace projetdotnet.Controllers
{
    public class ProductController : Controller
    {
        private  IProductRepository _ProductRepo;
        private ICategoryRepository _CategoryRepo;
        private IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductRepository ProductRepo, ICategoryRepository categoryRepo, IWebHostEnvironment webHostEnvironment)
        {
            _ProductRepo = ProductRepo;
            _CategoryRepo = categoryRepo;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _ProductRepo.GetAll().ToList();

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

            return View(objProductList);
        }
        public IActionResult Create()
        {
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
            return View();
        }
        [HttpPost]

        public IActionResult Create(Product obj , IFormFile? file)
        {

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if(file != null)
            {
                string fileName = Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName); //randomly name for the file +extension
                string productPath = Path.Combine(wwwRootPath, @"images\product");  //to save the image
                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                obj.ImageUrl = @"\images\product\" + fileName;
            }
                _ProductRepo.Add(obj);
                _ProductRepo.Save();
                TempData["success"] = "product created successfully";
                return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product productFromDb = _ProductRepo.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            // Repopulate the CategoryList in case of validation errors
            ViewBag.CategoryList = new SelectList(_CategoryRepo.GetAll(), "CategoryId", "Name");
            return View(productFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product obj, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); //randomly name for the file +extension
                string productPath = Path.Combine(wwwRootPath, @"images\product");  //to save the image
                if(!string.IsNullOrEmpty(obj.ImageUrl)) {
                    var oldImagePath = Path.Combine(wwwRootPath,obj.ImageUrl.TrimStart('/'));
                    if(System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                obj.ImageUrl = @"\images\product\" + fileName;
            }
          
            _ProductRepo.Update(obj);
                _ProductRepo.Save();
                TempData["success"] = "product updated successfully";
                return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product productFromDb = _ProductRepo.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product obj = _ProductRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound(obj);
            }
            _ProductRepo.Remove(obj);
            _ProductRepo.Save();
            TempData["success"] = "product deleted successfully";
            return RedirectToAction("Index");
        }


    }
}
