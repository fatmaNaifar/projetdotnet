using projetdotnet.Data;
using projetdotnet.Models;
using projetdotnet.Repository.IRepository;
using System.Drawing.Text;

namespace projetdotnet.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser> , IApplicationUserRepository
    {
       private ApplicationDbContext _db ;
       public ApplicationUserRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

    }
}
