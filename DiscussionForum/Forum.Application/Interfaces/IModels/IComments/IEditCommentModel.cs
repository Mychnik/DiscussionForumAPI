namespace Forum.Application.Interfaces.IModels.IComments
{
    public  interface IEditCommentModel
    {
        int commentId { get; set; }
        string AuthorId { get; set; }
        string Content { get; set; }
    }
}
