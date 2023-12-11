using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projetdotnet.Models;
using projetdotnet.Repository.IRepository;

namespace projetdotnet.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyRepository _CompanyRepo;

        public CompanyController(ICompanyRepository CompanyRepo)
        {
            _CompanyRepo = CompanyRepo;
            
        }
        public IActionResult Index()
        {
            List<Company> objCompanytList = _CompanyRepo.GetAll().ToList();

            // Fetch the list of categories from the repository
            IEnumerable<Company> companies = _CompanyRepo.GetAll();

          
            return View(objCompanytList);
        }
        public IActionResult Create()
        {
            // Fetch the list of categories from the repository
            IEnumerable<Company> companies = _CompanyRepo.GetAll();
            return View();
        }
        [HttpPost]

        public IActionResult Create(Company obj)
        {


            _CompanyRepo.Add(obj);
            _CompanyRepo.Save();
            TempData["success"] = "company created successfully";
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Company companyFromDb = _CompanyRepo.Get(u => u.Id == id);
            if (companyFromDb == null)
            {
                return NotFound();
            }
            return View(companyFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Company obj)
        {
       

            _CompanyRepo.Update(obj);
            _CompanyRepo.Save();
            TempData["success"] = "company updated successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Company companyFromDb = _CompanyRepo.Get(u => u.Id == id);
            if (companyFromDb == null)
            {
                return NotFound();
            }
            return View(companyFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Company obj = _CompanyRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound(obj);
            }
            _CompanyRepo.Remove(obj);
            _CompanyRepo.Save();
            TempData["success"] = "company deleted successfully";
            return RedirectToAction("Index");
        }


    }
}
