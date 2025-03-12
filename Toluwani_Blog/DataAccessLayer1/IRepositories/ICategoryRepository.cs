using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Get product Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category Object by Id</returns>
        DomainLayer.Models.BlogModels.Category? Get(int id);



        /// <summary>
        /// List of Category
        /// </summary>
        /// <returns>List of Category</returns>
        List<DomainLayer.Models.BlogModels.Category> Get();



        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="category"></param>
        void Delete(DomainLayer.Models.BlogModels.Category category);


        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Category Object</returns>
        DomainLayer.Models.BlogModels.Category Create(DomainLayer.Models.BlogModels.Category category);

        /// <summary>
        /// Update Category Details
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Updated Object</returns>
        DomainLayer.Models.BlogModels.Category? Update(DomainLayer.Models.BlogModels.Category category);
    }
}
