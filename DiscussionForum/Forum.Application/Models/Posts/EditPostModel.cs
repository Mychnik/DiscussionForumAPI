using Forum.Application.Interfaces.IModels;

namespace Forum.Application.Models.Posts
{
   public class EditPostModel : IEditPostModel
    {
        public string AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
    }
}
