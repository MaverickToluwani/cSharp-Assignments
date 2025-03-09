using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperMethods;
using BusinessLogicLayer.Service;
using DomainLayer.DTO.PostDTO;
using DomainLayer.DTO.UserDTO;
using DomainLayer.Models.BlogModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : Controller
    {

        IPostService _postService;
        PostMapper _postMapper;

        public PostController(IPostService postService, PostMapper postMapper)
        {
            _postService = postService;
            _postMapper = postMapper;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_postService.GetAllPost());
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            Post post = _postService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }


            PostDto postDto = _postMapper.MapPostToPostDto(post);

            return Ok(postDto);
        }

        [HttpGet]
        public IActionResult GetByAuthorId(int AuthorId)
        {
            List<Post> postList = _postService.GetPostByAuthorId(AuthorId, out string message);

            if (postList == null)
            {
                return NotFound();
            }

            return Ok(postList);
        }

        [HttpPost]
        public IActionResult CreatePost([FromBody] CreatePostRequest post)
        {


            Post mappedPost = _postMapper.MapCreatePostRequestToUser(post);


            Post? createdPost = _postService.CreatePost(mappedPost, out string message);

            if (createdPost == null)
            {
                return BadRequest(message);
            }

            PostDto CreatedPostDto = _postMapper.MapPostToPostDto(createdPost);

            return Ok(CreatedPostDto);
        }

        [HttpPost]
        public IActionResult UpdatePost([FromBody] UpdatePostRequest post)
        {
            Post mappedPost = _postMapper.MapUpdatePostRequestToUser(post);

            Post? PostUpdated = _postService.UpdatePost(mappedPost, out string message);

            if (PostUpdated is null)
            {
                return BadRequest(message);
            }

            PostDto UpdatedPostDto = _postMapper.MapPostToPostDto(PostUpdated);

            return Ok(UpdatedPostDto);
        }

        [HttpDelete]
        public IActionResult DeleteUser([FromBody] DeletePostRequest post)
        {
            Post mappedPost = _postMapper.MapDeletePostRequestToCategory(post);

            bool PostDeleted = _postService.DeletePost(mappedPost.Id, out string message);

            return Ok(PostDeleted);

        }
    }
}
