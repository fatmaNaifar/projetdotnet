using projetdotnet.Data;
using projetdotnet.Models;
using projetdotnet.Repository.IRepository;
using System.Linq.Expressions;

namespace projetdotnet.Repository
{
    public class CategoryRepository : Repository<Category> ,ICategoryRepository 
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
