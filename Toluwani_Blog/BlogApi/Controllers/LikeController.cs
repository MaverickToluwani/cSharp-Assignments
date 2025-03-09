using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperMethods;
using BusinessLogicLayer.Service;
using DomainLayer.DTO.LikeDTO;
using DomainLayer.DTO.PostDTO;
using DomainLayer.Models.BlogModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LikeController : Controller
    {
        ILikeService _likeServce;
        LikeMapper _likeMapper;
        public LikeController(LikeMapper likeMapper, ILikeService likeService)
        {
            _likeMapper = likeMapper;
            _likeServce = likeService;
        }

        [HttpGet]
        public IActionResult GetAllLikes()
        {
            return Ok(_likeServce.GetAllLikes());
        }

        [HttpGet]
        public IActionResult GetLikeByUserId(int Userid)
        {
            List<Like> UserLikes = _likeServce.GetLikeByUserId(Userid, out string message);

            if (!UserLikes.Any())
            {
                return NotFound();
            }

            return Ok(UserLikes);
        }

        [HttpGet]
        public IActionResult GetLikeByPostId(int PostId)
        {
            List<Like> PostLikes = _likeServce.GetLikeByUserId(PostId, out string message);

            if (!PostLikes.Any())
            {
                return NotFound();
            }

            return Ok(PostLikes);
        }

        [HttpDelete]
        public IActionResult Unlike([FromBody] LikeDto LikeDetails)
        {
            Like mappedLike = _likeMapper.MapLikeDtoToLike(LikeDetails);

            bool PostDeleted = _likeServce.UnlikePost(mappedLike, out string message);

            return Ok(PostDeleted);

        }

        [HttpGet]
        public IActionResult GetPostByUserIdAndPostId(LikeDto LikeDetails)
        {
            Like mappedLike = _likeMapper.MapLikeDtoToLike(LikeDetails);

            Like LikedPostByUser = _likeServce.GetPostByUserIdAndPostId(mappedLike, out string message);

            if (LikedPostByUser == null)
            {
                return NotFound();
            }

            return Ok(LikedPostByUser);
        }
    }
}
