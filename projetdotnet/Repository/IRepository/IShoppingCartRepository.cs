using NPOI.SS.Formula.Functions;
using projetdotnet.Models;
using System.Linq.Expressions;

namespace projetdotnet.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<shoppingCart>
    {
        void Update(shoppingCart shoppingCarts);
        void Save();
        IEnumerable<shoppingCart> GetAllCart(Expression<Func<shoppingCart, bool>> filter, string includeProperties = null);
    }
}
