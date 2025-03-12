using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperMethods;
using BusinessLogicLayer.UnitOfWorkServicesFolder;
using DomainLayer.DTO.LikeDTO;
using DomainLayer.Models.BlogModels;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Input;

namespace BlogApi.Controllers
{
    public class CommentController : Controller
    {

        //Comment? CreateComment(Comment comment, out string message);
        //bool DeleteComment(int id, out string message);
        //List<Comment> GetAllComment();
        //Comment? GetCommentById(int id);
        //Comment? UpdateCategory(Comment comment, out string message);
        //bool VerifyUsersCommentOnPost(Comment comment);

        IUnitOfWorkService _unitOfWork;
        public CommentController(IUnitOfWorkService unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllComments()
        {
            return Ok(_unitOfWork.commentService.GetAllComment());
        }

        [HttpGet]
        public IActionResult GetCommentById(int Userid)
        {
            Comment? UserComments = _unitOfWork.commentService.GetCommentById(Userid);

            if (UserComments == null)
            {
                return NotFound();
            }

            return Ok(UserComments);
        }

        //Comment? CreateComment(Comment comment, out string message);
        [HttpGet]
        public IActionResult CreateComment(Comment comment)
        {
            Comment? CreateComment = _unitOfWork.commentService.CreateComment(comment, out string message);

            if (CreateComment == null)
            {
                return NotFound();
            }

            return Ok(CreateComment);
        }

        ////bool DeleteComment(int id, out string message);
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            //Like mappedLike = _likeMapper.MapLikeDtoToLike(LikeDetails);

            bool PostDeleted = _unitOfWork.commentService.DeleteComment(id, out string message);

            return Ok(PostDeleted);

        }

        //UpdateCategory(Comment comment, out string message);
        [HttpGet]
        public IActionResult UpdateComment(Comment comment)
        {
            //Like mappedLike = _likeMapper.MapLikeDtoToLike(LikeDetails);

            Comment? CommentUpdate = _unitOfWork.commentService.UpdateComment(comment, out string message);

            if (CommentUpdate == null)
            {
                return NotFound();
            }

            return Ok(CommentUpdate);
        }
    }
}
