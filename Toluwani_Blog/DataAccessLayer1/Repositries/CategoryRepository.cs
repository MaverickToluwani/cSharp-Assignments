using DataAccessLayer.Data;
using DataAccessLayer.IRepositories;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositries
{
    public class CategoryRepository: ICategoryRepository
    {
        //private readonly ApplicationDbContext applicationDbContext;
        private ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public DomainLayer.Models.BlogModels.Category Create(DomainLayer.Models.BlogModels.Category category)
        {
            _applicationDbContext.CategoriesZ.Add(category);
            _applicationDbContext.SaveChanges();
            return category;
        }



        public void Delete(DomainLayer.Models.BlogModels.Category category)
        {
            _applicationDbContext.Remove(category);
            _applicationDbContext.SaveChanges();
        }

        public DomainLayer.Models.BlogModels.Category? Get(int id)
        {
            DomainLayer.Models.Category? category = _applicationDbContext.Categories.Find(id);
            return null;
        }

        public List<DomainLayer.Models.BlogModels.Category> Get()
        {
            return _applicationDbContext.CategoriesZ.ToList();
        }

        public DomainLayer.Models.BlogModels.Category? Update(DomainLayer.Models.BlogModels.Category category)
        {
            DomainLayer.Models.BlogModels.Category? existingCategory = _applicationDbContext.CategoriesZ.Find(category.Id);



            existingCategory.Name = category.Name;

            _applicationDbContext.CategoriesZ.Update(existingCategory);
            _applicationDbContext.SaveChanges();

            return existingCategory;

        }
    }
}
