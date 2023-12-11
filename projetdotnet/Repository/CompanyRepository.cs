using projetdotnet.Data;
using projetdotnet.Models;
using projetdotnet.Repository.IRepository;

namespace projetdotnet.Repository
{
    public class CompanyRepository : Repository<Company> , ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Company company)
        {
            _db.Companies.Update(company);
        }
    }
}
