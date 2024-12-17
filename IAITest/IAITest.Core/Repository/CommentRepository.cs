using IAITest.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IAITest.Core.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private string mainPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\");
        public async Task<List<Comment>> GetComments(int AdId = -1)
        {
            var path = Path.Combine(mainPath, @"comments.json");
            List<Comment> comments = new List<Comment>();
            try
            {
                if(File.Exists(path))
                {
                    var jsonComments = await File.ReadAllTextAsync(Path.Combine(mainPath, @"comments.json"));
                    comments = JsonSerializer.Deserialize<List<Comment>>(jsonComments);
                    if (AdId > 0)
                    {
                        comments = comments.Where(c => c.Id == AdId).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception($"There was an error Getting comments for Id {AdId}.");
            }
            return comments;
        }

        public async Task SaveComment(List<Comment> comments, Comment comment)
        {
            try
            {
                int id = 0;
                if (comments.Any())
                    // Get the last id and then increment by one for unique id
                    id = comments.Max(a => a.Id);
                id++;
                comment.Id = id;
                comment.Created = DateTime.Now;
                comments.Add(comment);
                var jsonComments = JsonSerializer.Serialize(comments);
                await File.WriteAllTextAsync(Path.Combine(mainPath, @"comments.json"), jsonComments);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Comment didn't save");
            }
        }
    }
}
