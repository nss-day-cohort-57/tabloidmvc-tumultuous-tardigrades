using TabloidMVC.Models;
using System.Collections.Generic;

namespace TabloidMVC.Repositories
{
    public interface ICommentRepository
    {
        void DeleteComment(int commentId);
        List<Comment> GetCommentsByPostId(int postId);
        void AddComment(Comment comment);
        Comment GetCommentById(int id);
    }
}
