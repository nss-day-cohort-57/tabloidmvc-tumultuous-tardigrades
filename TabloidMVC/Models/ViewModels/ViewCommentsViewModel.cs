using System.Collections.Generic;

namespace TabloidMVC.Models.ViewModels
{
    public class ViewCommentsViewModel
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
