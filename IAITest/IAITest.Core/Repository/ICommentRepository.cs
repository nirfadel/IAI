using IAITest.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAITest.Core.Repository
{
    public interface ICommentRepository
    {
        Task SaveComment(List<Comment> comments, Comment comment);
        Task<List<Comment>> GetComments(int AdId);
    }
}
