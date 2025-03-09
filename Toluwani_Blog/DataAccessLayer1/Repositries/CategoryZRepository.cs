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
    public class CategoryZRepository: ICategoryZRepository
    {
        //private readonly ApplicationDbContext applicationDbContext;
        private ApplicationDbContext _applicationDbContext;

        public CategoryZRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public CategoryZ Create(CategoryZ category)
        {
            _applicationDbContext.CategoriesZ.Add(category);
            _applicationDbContext.SaveChanges();
            return category;
        }



        public void Delete(CategoryZ category)
        {
            _applicationDbContext.Remove(category);
            _applicationDbContext.SaveChanges();
        }

        public CategoryZ? Get(int id)
        {
            Category? category = _applicationDbContext.Categories.Find(id);
            return null;
        }

        public List<CategoryZ> Get()
        {
            return _applicationDbContext.CategoriesZ.ToList();
        }

        public CategoryZ? Update(CategoryZ category)
        {
            CategoryZ? existingCategory = _applicationDbContext.CategoriesZ.Find(category.Id);



            existingCategory.Name = category.Name;

            _applicationDbContext.CategoriesZ.Update(existingCategory);
            _applicationDbContext.SaveChanges();

            return existingCategory;

        }
    }
}
