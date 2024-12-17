using IAITest.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAITest.Core.Services
{
    public interface ICommentService
    {
        Task<List<Comment>> GetComments(int AdId);

        Task<AdResponse> SaveNewComment(Comment comment);
    }
}
