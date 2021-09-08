using Forum.Application.Interfaces.IModels.IComments;

namespace Forum.Application.Models.Comments
{
   public class NewCommentModel : INewCommentModel
    {
        public string Content { get; set; }
        public int PostId { get; set; }
    }
}
