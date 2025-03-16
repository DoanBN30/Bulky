using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj, bool tracked = false)
        {
            Product product = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            _db.Entry<Product>(product).State = EntityState.Detached;
            product.Title = obj.Title;
            product.Description = obj.Description;  
            product.CategoryId = obj.CategoryId;
            product.ISBN = obj.ISBN;    
            product.Price = obj.Price;
            product.ListPrice = obj.ListPrice;
            product.Price50 = obj.Price50;
            product.Author = obj.Author;
            if (obj.ImageUrl != null)
            {
                product.ImageUrl = obj.ImageUrl;
            }
            _db.Products.Update(obj);
        }
    }
}