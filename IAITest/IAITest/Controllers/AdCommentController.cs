using IAITest.Core.Model;
using IAITest.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IAITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdCommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public AdCommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{AdId}")]
        public async Task<List<Comment>> Get(int AdId)
        {
            return await _commentService.GetComments(AdId);
        }

        [HttpPost]
        public async Task<AdResponse> Post(Comment comment)
        {
            return await _commentService.SaveNewComment(comment);
        }
    }
}
