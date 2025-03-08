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
    public class CategoryRepository : ICategory
    {
        //private readonly ApplicationDbContext applicationDbContext;
        private ApplicationDbContext _applicationDbContext;

        public  CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Category Create(Category category)
        {
            _applicationDbContext.Categories.Add(category);
            _applicationDbContext.SaveChanges();
            return category;
        }

       

        public void Delete(Category category)
        {
            _applicationDbContext.Remove(category);
            _applicationDbContext.SaveChanges(category);
        }

        public Category? Get(int id)
        {
            Category? category = _applicationDbContext.Categories.Find(id);
            return null;
        }

        public List<Category> Get()
        {
            return _applicationDbContext.Categories.ToList();
        }

        public Category? Update(Category category)
        {
            Category? existingCategory = _applicationDbContext.Categories.Find(category.Id);

            

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;

            _applicationDbContext.Categories.Update(existingCategory);
            _applicationDbContext.SaveChanges();

            return existingCategory;

        }

       
    }
}
