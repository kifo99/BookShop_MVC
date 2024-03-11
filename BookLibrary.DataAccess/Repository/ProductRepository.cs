using BookLibrary.DataAccess.Data;
using BookLibrary.DataAccess.Repository.IRepository;
using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == product.Id);

            if(objFromDb != null)
            {
                objFromDb.Title = product.Title;
                objFromDb.ISBN = product.ISBN;
                objFromDb.Price = product.Price;
                objFromDb.Price50 = product.Price50;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.Price100 = product.Price100;
                objFromDb.Description = product.Description;
                objFromDb.IdCategory = product.IdCategory;
                objFromDb.Author = product.Author;
                if(product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }

            }
        }
    }
}
