using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperMethods;
using Microsoft.AspNetCore.Mvc;
using DomainLayer.DTO.CategoryDTO;
using DataAccessLayer.UnitOfWorkFolder;
using BusinessLogicLayer.UnitOfWorkServicesFolder;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : Controller
    {
        //ICategorieService _categoryZService;
        IUnitOfWorkService _unitOfWork;
        CategoryMapper _categoryZMapper;

        public CategoryController(CategoryMapper categoryZMapper, IUnitOfWorkService unitOfWork)
        {
            //_categoryZService = categoryZService;
            _unitOfWork = unitOfWork;
            _categoryZMapper = categoryZMapper;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            return Ok(_unitOfWork.categoryService.GetAllCategory());
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            DomainLayer.Models.BlogModels.Category? category = _unitOfWork.categoryService.GetCategory(id);

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


            DomainLayer.Models.BlogModels.Category mappedCategory = _categoryZMapper.MapCategoryDtoToCategory(category);


            DomainLayer.Models.BlogModels.Category? createdCategory = _unitOfWork.categoryService.CreateCategory(mappedCategory, out string message);

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
            DomainLayer.Models.BlogModels.Category mappedCategory = _categoryZMapper.MapCategoryDtoToCategory(category);

            DomainLayer.Models.BlogModels.Category? categoryUpdated = _unitOfWork.categoryService.UpdateCategory(mappedCategory, out string message);

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
            DomainLayer.Models.BlogModels.Category mappedCategory = _categoryZMapper.MapDeleteCategoryZRequestToCategoryZ(category);

            bool categoryDeleted = _unitOfWork.categoryService.DeleteCategory(mappedCategory.Id, out string message);

            return Ok(categoryDeleted);
        }

    }
}
