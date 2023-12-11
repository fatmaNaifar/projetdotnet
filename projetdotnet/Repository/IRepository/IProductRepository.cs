using projetdotnet.Models;

namespace projetdotnet.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
        void Save();
    
    }
}
