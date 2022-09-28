using System.Collections.Generic;
using TabloidMVC.Models;
using TabloidMVC.Models.ViewModels;

namespace TabloidMVC.Repositories
{
    public interface IPostRepository
    {
        void Add(Post post);
        List<Post> GetAllPublishedPosts();
        List<Post> GetUsersPublishedPosts(int id);
        Post GetPublishedPostById(int id);
        Post GetUserPostById(int id, int userProfileId);
        void Delete(int id);
        void UpdatePost(Post post);
    }
}