using BusinessLogicLayer.IService;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositries;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class CategoriesZService: ICategoriesZService
    {
        //Private variable that stores the ICategoryRepository object
        private readonly ICategoryZRepository _categoryZRepository;

        //Constructor of the CategoryService class
        //Require a ICategoryRepository object when creating the CategoryService class
        public CategoriesZService(ICategoryZRepository categoryZRepository)
        {
            //this assigns the passed in categoryRepository to the private variable _categoryRepository
            _categoryZRepository = categoryZRepository;
        }

        public CategoryZ? CreateCategory(CategoryZ category, out string message)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                message = "Name cannot be empty";
                return null;
            }

            CategoryZ result = _categoryZRepository.Create(category);
            message = "Successful";
            return result;
        }



        public bool DeleteCategory(int id, out string message)
        {
            //CategoryZ? category = _categoryZRepository.Get(id);
            CategoryZ Result = GetCategory(id);

            if (Result == null)
            {
                message = "Invalid id";
                return false;
            }

            _categoryZRepository.Delete(Result);
            message = "Deleted Successfully";
            return true;

        }

        public List<CategoryZ> GetAllCategory()
        {
            return _categoryZRepository.Get();
        }

        public CategoryZ? GetCategory(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _categoryZRepository.Get(id);
        }

        public CategoryZ? UpdateCategory(CategoryZ category, out string message)
        {
            if (category.Id <= 0)
            {
                message = "Invalid Id";
                return null;
            }

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                message = "Name is Required";
                return null;
            }

            CategoryZ? updatedCategory = _categoryZRepository.Update(category);

            if (updatedCategory is null)
            {
                message = "Category not found";
                return null;
            }

            message = "Successfully Upated";
            return updatedCategory;
        }
    }
}
