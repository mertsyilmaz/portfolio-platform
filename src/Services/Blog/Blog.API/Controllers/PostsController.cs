using Blog.Application.Posts;
using Blog.Contracts.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ICreatePostService _createPostService;
        private readonly IGetPostsService _getPostsService;
        private readonly IGetPostByIdService _getPostByIdService;
        private readonly IUpdatePostService _updatePostService;
        private readonly IDeletePostService _deletePostService;

        public PostsController(
            ICreatePostService createPostService,
            IGetPostsService getPostsService,
            IGetPostByIdService getPostByIdService,
            IUpdatePostService updatePostService,
            IDeletePostService deletePostService)
        {
            _createPostService = createPostService;
            _getPostsService = getPostsService;
            _getPostByIdService = getPostByIdService;
            _updatePostService = updatePostService;
            _deletePostService = deletePostService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostRequest request)
        {
            var result = await _createPostService.CreateAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getPostsService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getPostByIdService.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdatePostRequest request)
        {
            var result = await _updatePostService.UpdateAsync(id, request);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _deletePostService.DeleteAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
