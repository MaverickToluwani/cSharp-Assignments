using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IService
{
    public interface IPostService
    {
        Post? CreatePost(Post post, out string message);

        List<Post> GetPostByAuthorId(int AuthorId, out string message);

        bool DeletePost(int id, out string message);

        List<Post> GetAllPost();

        Post? GetPost(int id);

        Post? UpdatePost(Post post, out string message);
    }
}
