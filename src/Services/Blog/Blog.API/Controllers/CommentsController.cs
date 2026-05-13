using Blog.Application.Comments;
using Blog.Contracts.Comments;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICreateCommentService _createCommentService;
        private readonly IGetCommentsService _getCommentsService;
        private readonly IGetCommentByIdService _getCommentByIdService;
        private readonly IGetCommentsByPostIdService _getCommentsByPostIdService;
        private readonly IUpdateCommentService _updateCommentService;
        private readonly IDeleteCommentService _deleteCommentService;

        public CommentsController(
            ICreateCommentService createCommentService,
            IGetCommentsService getCommentsService,
            IGetCommentByIdService getCommentByIdService,
            IGetCommentsByPostIdService getCommentsByPostIdService,
            IUpdateCommentService updateCommentService,
            IDeleteCommentService deleteCommentService)
        {
            _createCommentService = createCommentService;
            _getCommentsService = getCommentsService;
            _getCommentByIdService = getCommentByIdService;
            _getCommentsByPostIdService = getCommentsByPostIdService;
            _updateCommentService = updateCommentService;
            _deleteCommentService = deleteCommentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentRequest request)
        {
            var result = await _createCommentService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getCommentsService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getCommentByIdService.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpGet("post/{postId:guid}")]
        public async Task<IActionResult> GetByPostId(Guid postId)
        {
            var result = await _getCommentsByPostIdService.GetByPostIdAsync(postId);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateCommentRequest request)
        {
            var result = await _updateCommentService.UpdateAsync(id, request);

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteCommentService.DeleteAsync(id);

            return NoContent();
        }
    }
}
