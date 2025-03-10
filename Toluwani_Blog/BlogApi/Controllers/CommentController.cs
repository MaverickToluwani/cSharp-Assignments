using BusinessLogicLayer.IService;
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
        ICommentService _commentService;
        
    }
}
