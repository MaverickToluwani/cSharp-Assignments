using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.IService;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositries;
using DomainLayer.Models;

namespace BusinessLogicLayer.CategoryService
{
    public class CategoryService : ICategoryService
    {
        //Private variable that stores the ICategoryRepository object
        private readonly ICategory _categoryRepository;

        //Constructor of the CategoryService class
        //Require a ICategoryRepository object when creating the CategoryService class
        public CategoryService(ICategory categoryRepository)
        {
            //this assigns the passed in categoryRepository to the private variable _categoryRepository
            _categoryRepository = categoryRepository;
        }

        public Category? CreateCategory(Category category, out string message)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                message = "Name cannot be empty";
                return null;
            }

            if (string.IsNullOrWhiteSpace(category.Description))
            {
                message = "Description Cannot be empty";
                return null;
            }

            Category result = _categoryRepository.Create(category);
            message = "Successful";
            return result;
        }

            

        public bool DeleteCategory(int id, out string message)
        {
            if(id <= 0)
            {
                message = "Invalid";
                return false;
            }

            Category? category = _categoryRepository.Get(id);
            
            if(category == null)
            {
                message = "Return a Number";
                return false;
            }

            _categoryRepository.Delete(category);
            message = "Deleted Successfully";
            return true;

        }

        public List<Category> GetAllCategory()
        {
            return _categoryRepository.Get();
        }

        public Category? GetCategory(int id)
        {
            if(id <= 0)
            {
                return null;
            }
            return _categoryRepository.Get(id);
        }

        public Category? UpdateCategory(Category category, out string message)
        {
            if(category.Id <= 0)
            {
                message = "Invalid Id";
                return null;
            }

            if (string.IsNullOrWhiteSpace(category.Description))
            {
                message = "Description is Required";
                return null;
            }

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                message = "Name is Required";
                return null;
            }

            Category? updatedCategory = _categoryRepository.Update(category);

            if(updatedCategory is null)
            {
                message = "Category not found";
                return null;
            }

            message = "Successfully Upated";
            return updatedCategory;
        }
    }
}
