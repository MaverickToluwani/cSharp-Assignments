using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface ICategoryZRepository
    {
        /// <summary>
        /// Get product Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category Object by Id</returns>
        CategoryZ? Get(int id);



        /// <summary>
        /// List of Category
        /// </summary>
        /// <returns>List of Category</returns>
        List<CategoryZ> Get();



        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="category"></param>
        void Delete(CategoryZ category);


        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Category Object</returns>
        CategoryZ Create(CategoryZ category);

        /// <summary>
        /// Update Category Details
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Updated Object</returns>
        CategoryZ? Update(CategoryZ category);
    }
}
