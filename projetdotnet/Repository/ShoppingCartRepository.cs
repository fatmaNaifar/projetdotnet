using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using projetdotnet.Data;
using projetdotnet.Models;
using projetdotnet.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace projetdotnet.Repository
{
    public class ShoppingCartRepository : Repository<shoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // Corrected the return type to match the Repository<T> pattern
        public IEnumerable<shoppingCart> GetAllCart(Expression<Func<shoppingCart, bool>> filter, string includeProperties = null)
        {
            IQueryable<shoppingCart> query = dbSet; // Assuming dbSet is DbSet<shoppingCart>

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.ToList(); // Corrected to return a collection
        }



        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(shoppingCart shoppingCarts)
        {
            // Corrected the usage of Update for Entity Framework
            _db.Update(shoppingCarts);
        }
    }
}
