using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IService
{
    public interface ICommentService
    {
        Comment? CreateComment(Comment comment, out string message);

        bool DeleteComment(int id, out string message);

        List<Comment> GetAllComment();

        Comment? GetCommentById(int id);

        Comment? UpdateCategory(Comment comment, out string message);

        bool VerifyUsersCommentOnPost(Comment comment);
        
    }
}
