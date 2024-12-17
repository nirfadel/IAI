using IAITest.Core.Model;
using IAITest.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAITest.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<List<Comment>> GetComments(int AdId)
        {
            return await _commentRepository.GetComments(AdId);
        }

        public async Task<AdResponse> SaveNewComment(Comment comment)
        {
            try
            {
                var comments = await GetComments(-1);
                await _commentRepository.SaveComment(comments, comment);
                return new AdResponse { Status = System.Net.HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new AdResponse { Status = System.Net.HttpStatusCode.NotFound, Error = ex.Message };
            }
        }
    }
}
