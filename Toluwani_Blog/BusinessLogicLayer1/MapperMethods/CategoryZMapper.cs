using DomainLayer.DTO;
using DomainLayer.DTO.CategoryDTO;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MapperMethods
{
    public class CategoryZMapper
    {
        public CategoryZ MapCategoryDtoToCategory(CategoryZDto CategoryZDto)
        {
            return new CategoryZ
            {
                Name = CategoryZDto.Name,
            };
        }

        public CategoryZDto MapCategoryToCategoryZDto(CategoryZ category)
        {
            return new CategoryZDto
            {
                Name = category.Name,
            };
        }

        public CategoryZ MapDeleteCategoryZRequestToCategoryZ(DeleteRequestCategoryZDto deleteRtCategoryDto)
        {
            return new CategoryZ
            {
                Id = deleteRtCategoryDto.Id
            };
        }
    }
}
