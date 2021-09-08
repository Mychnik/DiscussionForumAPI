using Forum.Application.Interfaces.IModels.IComments;
using System;

namespace Forum.Application.Models.Comments
{
   public class CommentInPostModel : ICommentInPostModel
    {
        public string AuthorId { get; set; }
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }
    }
}
