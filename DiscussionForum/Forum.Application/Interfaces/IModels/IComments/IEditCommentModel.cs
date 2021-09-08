namespace Forum.Application.Interfaces.IModels.IComments
{
    public  interface IEditCommentModel
    {
        string AuthorId { get; set; }
        string Content { get; set; }
    }
}
