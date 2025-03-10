using DomainLayer.DTO;
using DomainLayer.DTO.CommentDTO;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MapperMethods
{
    public class CommentMapper
    {
        public Comment MapCommentDtoRequestToComment(CommentsDTO CreateComment)
        {
            return new Comment
            {
                Content = CreateComment.Content,
                UserId = CreateComment.UserId,
                PostId = CreateComment.PostId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public CommentsDTO MapCommentToCommentDto(Comment comment)
        {
            return new CommentsDTO
            {
                Content = comment.Content,
                UserId = comment.UserId,
                PostId = comment.PostId,
            };
        }

        public Category MapUpdateCommentRequestToComment(UpdateRequestCategoryDto updateRequestCategoryDto)
        {
            return new Category
            {
                Id = updateRequestCategoryDto.Id,
                Name = updateRequestCategoryDto.Name,
                Description = updateRequestCategoryDto.Description,
            };
        }

        public Category MapDeleteCategoryRequestToCategory(DeleteRequestCategoryDto deleteRequestCategoryDto)
        {
            return new Category
            {
                Id = deleteRequestCategoryDto.Id
            };
        }
    }
}
