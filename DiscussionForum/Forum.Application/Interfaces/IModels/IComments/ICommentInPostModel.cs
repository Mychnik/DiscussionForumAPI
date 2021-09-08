using System;

namespace Forum.Application.Interfaces.IModels.IComments
{
    public interface ICommentInPostModel
    {
        string AuthorId { get; set; }
        int CommentId { get; set; }
        string Content { get; set; }
        DateTime Date { get; set; }
        int PostId { get; set; }
    }
}
