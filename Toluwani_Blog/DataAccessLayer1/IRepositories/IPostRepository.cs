using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IPostRepository
    {
        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>user Object by Id</returns>
        Post? GetPostById(int id);


        /// <summary>
        /// Get user by role
        /// </summary>
        /// <param name="AuthorId"></param>
        /// <returns>user Object by Id</returns>
        List<Post> GetPostByAuthorId(int AuthorId);


        /// <summary>
        /// All users
        /// </summary>
        /// <returns>List of users</returns>
        List<Post> GetAllPost();



        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="post"></param>
        void DeletePost(Post post);


        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="post"></param>
        /// <returns>User Object</returns>
        Post CreatePost(Post post);

        /// <summary>
        /// Update user Details
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Updated Object</returns>
        Post? UpdatePost(Post post);
    }
}
