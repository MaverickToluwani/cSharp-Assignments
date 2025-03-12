using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperMethods;
using BusinessLogicLayer.Service;
using BusinessLogicLayer.UnitOfWorkServicesFolder;
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
        //ILikeService _likeServce;
        IUnitOfWorkService _unitOfWork;
        LikeMapper _likeMapper;
        public LikeController(LikeMapper likeMapper, IUnitOfWorkService unitOfWork)
        {
            _likeMapper = likeMapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllLikes()
        {
            return Ok(_unitOfWork.likeService.GetAllLikes());
        }

        [HttpGet]
        public IActionResult GetLikeByUserId(int Userid)
        {
            List<Like> UserLikes = _unitOfWork.likeService.GetLikeByUserId(Userid, out string message);

            if (!UserLikes.Any())
            {
                return NotFound();
            }

            return Ok(UserLikes);
        }

        [HttpGet]
        public IActionResult GetLikeByPostId(int PostId)
        {
            List<Like> PostLikes = _unitOfWork.likeService.GetLikeByUserId(PostId, out string message);

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

            bool PostDeleted = _unitOfWork.likeService.UnlikePost(mappedLike, out string message);

            return Ok(PostDeleted);

        }

        [HttpGet]
        public IActionResult GetPostByUserIdAndPostId(LikeDto LikeDetails)
        {
            Like mappedLike = _likeMapper.MapLikeDtoToLike(LikeDetails);

            Like LikedPostByUser = _unitOfWork.likeService.GetPostByUserIdAndPostId(mappedLike, out string message);

            if (LikedPostByUser == null)
            {
                return NotFound();
            }

            return Ok(LikedPostByUser);
        }
    }
}
