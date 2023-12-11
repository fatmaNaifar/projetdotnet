using projetdotnet.Models;

namespace projetdotnet.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>

    {
        void Update(Category category);
        void Save();
    }
}
