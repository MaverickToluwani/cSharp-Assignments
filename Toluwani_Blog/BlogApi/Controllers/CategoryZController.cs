using BusinessLogicLayer.CategoryService;
using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperMethods;
using BusinessLogicLayer.Service;
using DomainLayer.DTO;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using Microsoft.AspNetCore.Mvc;
using DomainLayer.DTO.CategoryDTO;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryZController : Controller
    {
        ICategoriesZService _categoryZService;
        CategoryZMapper _categoryZMapper;

        public CategoryZController(ICategoriesZService categoryZService, CategoryZMapper categoryZMapper)
        {
            _categoryZService = categoryZService;
            _categoryZMapper = categoryZMapper;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            return Ok(_categoryZService.GetAllCategory());
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            CategoryZ category = _categoryZService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }


           CategoryZDto categoryDto = _categoryZMapper.MapCategoryToCategoryZDto(category);

            return Ok(categoryDto);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryZDto category)
        {


            CategoryZ mappedCategory = _categoryZMapper.MapCategoryDtoToCategory(category);


            CategoryZ? createdCategory = _categoryZService.CreateCategory(mappedCategory, out string message);

            if (createdCategory == null)
            {
                return BadRequest(message);
            }

            CategoryZDto CreatedCategoryDto = _categoryZMapper.MapCategoryToCategoryZDto(createdCategory);
            return Ok(CreatedCategoryDto);
        }

        [HttpPost]
        public IActionResult UpdateCategory([FromBody] CategoryZDto category)
        {
            CategoryZ mappedCategory = _categoryZMapper.MapCategoryDtoToCategory(category);

            CategoryZ? categoryUpdated = _categoryZService.UpdateCategory(mappedCategory, out string message);

            if (categoryUpdated is null)
            {
                return BadRequest(message);
            }

            CategoryZDto UpdatedCategoryDto = _categoryZMapper.MapCategoryToCategoryZDto(categoryUpdated);

            return Ok(UpdatedCategoryDto);
        }

        [HttpDelete]
        public IActionResult DeleteCategory([FromBody] DeleteRequestCategoryZDto category)
        {
            CategoryZ mappedCategory = _categoryZMapper.MapDeleteCategoryZRequestToCategoryZ(category);

            bool categoryDeleted = _categoryZService.DeleteCategory(mappedCategory.Id, out string message);

            return Ok(categoryDeleted);
        }

    }
}
