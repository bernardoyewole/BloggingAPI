using AutoMapper;
using BLL;
using Entities.DTO;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var listPosts = await _postService.GetPosts();
            List<PostDTO> posts = _mapper.Map<List<PostDTO>>(listPosts);

            return Ok(posts);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetPostsById(int Id)
        {
            Post post = await _postService.GetPostById(Id);
            PostDTO postDTO = _mapper.Map<PostDTO>(post);

            if (postDTO == null)
            {
                return NotFound();
            } else
            {
                return Ok(postDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPosts(Post post)
        {
            await _postService.AddPost(post);
            return Ok("Post Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePosts(Post post)
        {
            await _postService.UpdatePost(post);
            return Ok("Post updated successfully");
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeletePosts(int Id)
        {
            await _postService.DeletePost(Id);
            return Ok("Post deleted successfully");
        }
    }
}
