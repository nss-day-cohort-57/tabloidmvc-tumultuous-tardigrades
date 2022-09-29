using System.Collections.Generic;
using TabloidMVC.Models;
using TabloidMVC.Models.ViewModels;

namespace TabloidMVC.Repositories
{
    public interface IReactionRepository
    {
        void Add(Reaction reaction);
        List<Reaction> GetAll();
    }
}
