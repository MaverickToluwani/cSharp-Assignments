using BusinessLogicLayer.IService;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositries;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class CommentService: ICommentService
    {
        //Private variable that stores the ICategoryRepository object
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        //Constructor of the CategoryService class
        //Require a ICategoryRepository object when creating the CategoryService class
        public CommentService(ICommentRepository commentRepository, IPostRepository postRepository, IUserRepository userRepository)
        {
            //this assigns the passed in categoryRepository to the private variable _categoryRepository
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;

        }

        public Comment? CreateComment(Comment comment, out string message)
        {
            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                message = "Comment cannot be empty";
                return null;
            }
            bool isUserIdPostIdValid = VerifyUsersCommentOnPost(comment);

            if(isUserIdPostIdValid == false)
            {
                message = "User or post does not exist";
                return null;
            }

            Comment result = _commentRepository.Create(comment);

            message = "Successful";
            return result;
        }


        public bool DeleteComment(int id, out string message)
        {
            //CategoryZ? category = _categoryZRepository.Get(id);
            Comment? Result = GetCommentById(id);

            if (Result == null)
            {
                message = "Invalid id";
                return false;
            }

            _commentRepository.Delete(Result);
            message = "Deleted Successfully";
            return true;
        }

        public List<Comment> GetAllComment()
        {
            return _commentRepository.Get();
        }

        public Comment? GetCommentById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _commentRepository.Get(id);
        }

        public Comment? UpdateCategory(Comment comment, out string message)
        {
            if (comment.Id <= 0)
            {
                message = "Invalid Id";
                return null;
            }

            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                message = "Comment cannot be empty";
                return null;
            }

            bool isUserIdPostIdValid = VerifyUsersCommentOnPost(comment);

            if (isUserIdPostIdValid == false)
            {
                message = "User or post does not exist";
                return null;
            }

            Comment? updatedComment = _commentRepository.Update(comment);

            if (updatedComment is null)
            {
                message = "comment not found";
                return null;
            }

            message = "Successfully Upated";
            return updatedComment;
        }

        public bool VerifyUsersCommentOnPost(Comment comment)
        {
            Post? GetPost = _postRepository.GetPostById(comment.PostId);

            if (GetPost == null)
            {
                return false;
            }
            User? GetUser = _userRepository.GetUser(comment.UserId);

            if (GetUser == null)
            {
                return false;
            }
            return true;
        }
    }
}
