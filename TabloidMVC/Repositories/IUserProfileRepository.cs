using System.Collections.Generic;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface IUserProfileRepository
    {
        UserProfile GetByEmail(string email);
        List<UserProfile> GetAll();
        UserProfile GetUserProfileById(int id);
        void AddUserProfile(UserProfile profile);
        void DeactivateUser(int id);
    }
}