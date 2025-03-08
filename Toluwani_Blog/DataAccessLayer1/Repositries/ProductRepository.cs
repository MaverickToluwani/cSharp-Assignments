using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.IRepositories;
using DomainLayer.Models;

namespace DataAccessLayer.Repositries
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext applicationDbContext;
        private ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
        
            _applicationDbContext = applicationDbContext;
        }



        public Product Create(Product product)
        {
            _applicationDbContext.Products.Add(product);
            _applicationDbContext.SaveChanges();
            return product;
        }

        public void Delete(Product product)
        {
            _applicationDbContext.Remove(product);
            _applicationDbContext.SaveChanges(product);
        }

        public Product? Update(Product product)
        {
             Product?  existingProduct = _applicationDbContext.Products.Find(product.Id);

            if(existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.CreatedAt = product.CreatedAt;

            _applicationDbContext.Products.Update(existingProduct);
            _applicationDbContext.SaveChanges();

            return existingProduct;

        }


        public List<Product> Get()
        {
            return _applicationDbContext.Products.ToList();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
