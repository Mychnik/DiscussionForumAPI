using System;

namespace Forum.Application.Interfaces.IModels
{
    public interface IPostInListModel
    {
        string AuthorId { get; set; }
        int CategoryId { get; set; }
        string Content { get; set; }
        DateTime Date { get; set; }
        int PostId { get; set; }
        string Title { get; set; }
    }
}
