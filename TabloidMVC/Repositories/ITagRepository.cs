using System.Collections.Generic;
using TabloidMVC.Controllers;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetAll();
        Tag GetTagById(int id);
        void UpdateTag(Tag tag);
        void AddTag(Tag tag);
        void DeleteTag(int id);
    }
}
