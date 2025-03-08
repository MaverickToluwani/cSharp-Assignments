using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperMethods;
using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        CategoryMapper _categoryMapper;

        public CategoryController(ICategoryService categoryService, CategoryMapper categoryMapper)
        {
            _categoryService = categoryService;
            _categoryMapper = categoryMapper;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            return Ok(_categoryService.GetAllCategory());
        }

        //[HttpGet]
        //public IActionResult GetById(int id)
        //{
        //    Category category = _categoryService.GetUser(id);

        //    if(category == null)
        //    {
        //        return NotFound();
        //    }

           
        //    CategoryDto categoryDto = _categoryMapper.MapCategoryToCategoryDto(category);

        //    return Ok(categoryDto);
        //}

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateRequestCategoryDto category)
        {
            

            Category mappedCategory = _categoryMapper.MapCategoryRequestToCategory(category);


            Category? createdCategory = _categoryService.CreateCategory(mappedCategory, out string message);

            if (createdCategory == null)
            {
                return BadRequest(message);
            }

            CategoryDto CreatedCategoryDto = _categoryMapper.MapCategoryToCategoryDto(createdCategory);
            return Ok(CreatedCategoryDto);
        }

        [HttpPost]
        public IActionResult UpdateCategory([FromBody]UpdateRequestCategoryDto category)
        {
            Category mappedCategory = _categoryMapper.MapUpdateCategoryRequestToCategory(category);
            
            Category? categoryUpdated = _categoryService.UpdateCategory(mappedCategory, out string message);

            if(categoryUpdated is null)
            {
                return BadRequest(message);
            }

            CategoryDto UpdatedCategoryDto = _categoryMapper.MapCategoryToCategoryDto(categoryUpdated);

            return Ok(UpdatedCategoryDto);
        }

        [HttpDelete]
        public  IActionResult DeleteCategory([FromBody]DeleteRequestCategoryDto category)
        {
            Category mappedCategory = _categoryMapper.MapDeleteCategoryRequestToCategory(category);
            
             bool categoryDeleted = _categoryService.DeleteCategory(mappedCategory.Id, out string message);

            return Ok(categoryDeleted);



        }






    }
}
