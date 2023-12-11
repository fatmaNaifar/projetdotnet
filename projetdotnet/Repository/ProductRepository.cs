using projetdotnet.Data;
using projetdotnet.Models;
using projetdotnet.Repository.IRepository;

namespace projetdotnet.Repository
{
   public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product product)
        {
            _db.Products.Update(product);
        }
    }
}
