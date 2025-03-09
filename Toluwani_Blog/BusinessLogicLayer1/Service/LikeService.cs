using BusinessLogicLayer.IService;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Migrations;
using DataAccessLayer.Repositries;
using DomainLayer.DTO.UserDTO;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public LikeService(ILikeRepository likeRepository, IPostRepository postRepository, IUserRepository userRepository)
        {
            _likeRepository = likeRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public List<Like> GetAllLikes()
        {
            return _likeRepository.GetAllLikes();
        }

        public List<Like> GetLikeByPostId(int PostId, out string message)
        {
            if (PostId <= 0)
            {
                message = "Invalid PostId";
                return null;
            }

            Post? postData = _postRepository.GetPostById(PostId);

            if (postData == null)
            {
                message = "Post not found";
                return null;
            }
            message = "fetched successfully";
            return _likeRepository.GetLikeByPostId(PostId);
        }

        public List<Like> GetLikeByUserId(int UserId, out string message)
        {
            if (UserId <= 0)
            {
                message = "Invalid PostId";
                return null;
            }

            User? userData = _userRepository.GetUser(UserId);

            if(userData == null)
            {
                message = "User not found";
                return null;
            }
            message = "List of posts liked by user fetched successfully";
            return _likeRepository.GetLikeByUserId(UserId);

        }

        public Like LikePost(Like like, out string message)
        {
            if (like.UserId <= 0 || like.PostId <= 0)
            {
                message = "Invalid post Id or Reader Id";
                return null;
            }
            User? fetchUser = _userRepository.GetUser(like.UserId);
            Post? fetchPost = _postRepository.GetPostById(like.PostId);

            if (fetchUser == null || fetchPost == null)
            {
                message = "User or Post does not exist";
                return null;
            }
            message = "Post Liked successfully";

            Like likedPost = _likeRepository.LikePost(like);
            return likedPost;

        }

        public bool UnlikePost(Like like, out string message)
        {
            //if (like.UserId <= 0 || like.PostId <= 0)
            //{
            //    message = "Invalid post Id or Reader Id";
            //    return false;
            //}

            //List<Like> LikedPost = _likeRepository.GetLikeByPostId(like.PostId);

            //List<Like> UserLikedPost = _likeRepository.GetLikeByUserId(like.UserId);

            //if (!LikedPost.Any() || !UserLikedPost.Any())
            //{
            //    message = "Post or user not found";
            //    return false;
            //}

            Like LikeData = _likeRepository.GetPostByUserIdAndPostId(like);

            if (LikeData == null)
            {
                message = "Post or user not found";
                return false;
            }

            _likeRepository.UnlikePost(LikeData);

            message = "Unliked Successfully";
            return true;
        }

        public Like GetPostByUserIdAndPostId(Like like, out string message)
        {
            if (like.UserId <= 0 || like.PostId <= 0)
            {
                message = "Invalid post Id or Reader Id";
                return null;
            }

            List<Like> LikedPost = _likeRepository.GetLikeByPostId(like.PostId);

            List<Like> UserLikedPost = _likeRepository.GetLikeByUserId(like.UserId);

            if (!LikedPost.Any() || !UserLikedPost.Any())
            {
                message = "Post or user not found";
                return null;
            }

            Like LikedPostByUser = _likeRepository.GetPostByUserIdAndPostId(like);
            message = "fetched Successfully";

            return LikedPostByUser;
        }
    }
}
