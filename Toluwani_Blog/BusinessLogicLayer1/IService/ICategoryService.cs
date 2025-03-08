using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace BusinessLogicLayer.IService
{
    public interface ICategoryService
    {
        /// <summary>
        ///     Get category object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category object</returns>
        Category GetCategory(int id);


        /// <summary>
        ///     Get all category in the database
        /// </summary>
        /// <returns>List of Category Object</returns>
        List<Category> GetAllCategory();

        /// <summary>
        ///     Remove a Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteCategory(int id, out string message);


        /// <summary>
        ///     Modify a Category object
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Uodated Object</returns>
        Category? UpdateCategory(Category category, out string message);


        /// <summary>
        ///     Create a Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Create a new Category object</returns>
        Category? CreateCategory(Category category, out string message);
    }
}
