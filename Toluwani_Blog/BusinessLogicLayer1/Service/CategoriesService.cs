using BusinessLogicLayer.IService;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositries;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class CategoriesService: ICategorieService
    {
        //Private variable that stores the ICategoryRepository object
        //private readonly ICategoryRepository _categoryZRepository;
        private readonly IUnitOfWork _unitOfWork;

        //Constructor of the CategoryService class
        //Require a ICategoryRepository object when creating the CategoryService class
        public CategoriesService(IUnitOfWork unitOfWork)
        {
            //this assigns the passed in categoryRepository to the private variable _categoryRepository
            //_categoryZRepository = categoryZRepository;
            _unitOfWork = unitOfWork;
        }

        public DomainLayer.Models.BlogModels.Category? CreateCategory(DomainLayer.Models.BlogModels.Category category, out string message)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                message = "Name cannot be empty";
                return null;
            }

            DomainLayer.Models.BlogModels.Category result = _unitOfWork.categoryRepository.Create(category);
            message = "Successful";
            return result;
        }



        public bool DeleteCategory(int id, out string message)
        {
            //CategoryZ? category = _categoryZRepository.Get(id);
            DomainLayer.Models.BlogModels.Category Result = GetCategory(id);

            if (Result == null)
            {
                message = "Invalid id";
                return false;
            }

            _unitOfWork.categoryRepository.Delete(Result);
            message = "Deleted Successfully";
            return true;

        }

        public List<DomainLayer.Models.BlogModels.Category> GetAllCategory()
        {
            return _unitOfWork.categoryRepository.Get();
        }

        public DomainLayer.Models.BlogModels.Category? GetCategory(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _unitOfWork.categoryRepository.Get(id);
        }

        public DomainLayer.Models.BlogModels.Category? UpdateCategory(DomainLayer.Models.BlogModels.Category category, out string message)
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

            DomainLayer.Models.BlogModels.Category? updatedCategory = _unitOfWork.categoryRepository.Update(category);

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
