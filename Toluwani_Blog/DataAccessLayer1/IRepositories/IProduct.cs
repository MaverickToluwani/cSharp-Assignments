using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DataAccessLayer.IRepositories
{
    public interface IProduct
    {
        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns>Product Object</returns>
        Product Get(int id);


        /// <summary>
        /// Get all Product
        /// </summary>
        /// <returns>List of Product</returns>
        List<Product> Get();


        /// <summary>
        /// Delete Product Object
        /// </summary>
        /// <param name="product"></param>
        void Delete(Product product);


        /// <summary>
        /// Create Product 
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Product Object</returns>
        Product Create(Product product);


        /// <summary>
        /// Update Product details
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Updated Product</returns>
        Product? Update(Product product);
    }
}
