using projetdotnet.Models;

namespace projetdotnet.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company company);
        void Save();
    }
}
