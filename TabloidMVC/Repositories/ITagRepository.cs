﻿using System.Collections.Generic;
using TabloidMVC.Controllers;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetAll();
        void AddTag(Tag tag);
    }
}
