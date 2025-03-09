using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface ILikeRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        Like LikePost(Like like);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="like"></param>
        void UnlikePost(Like like);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns></returns>
        List<Like> GetLikeByPostId(int PostId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns></returns>
        List<Like> GetLikeByUserId(int PostId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<Like> GetAllLikes();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        Like GetPostByUserIdAndPostId(Like like);
    }
}
