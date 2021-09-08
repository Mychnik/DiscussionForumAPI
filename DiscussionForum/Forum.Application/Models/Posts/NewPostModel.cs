using Forum.Application.Interfaces.IModels;

namespace Forum.Application.Models.Posts
{
  public  class NewPostModel : INewPostModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
    }
}
