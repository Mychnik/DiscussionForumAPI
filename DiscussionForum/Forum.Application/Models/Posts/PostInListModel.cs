using Forum.Application.Interfaces.IModels;
using System;

namespace Forum.Application.Models.Posts
{
   public class PostInListModel : IPostInListModel
    {
        public string AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
    
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
    }
}
