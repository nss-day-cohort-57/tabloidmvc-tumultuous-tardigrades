using TabloidMVC.Models;
using System.Collections.Generic;

namespace TabloidMVC.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetCommentsByPostId(int postId);
        void AddComment(Comment comment);
        void UpdateComment(Comment comment);
        Comment GetCommentById(int id);
    }
}
