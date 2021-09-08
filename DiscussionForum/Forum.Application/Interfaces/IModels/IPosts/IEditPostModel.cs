namespace Forum.Application.Interfaces.IModels
{
    public interface IEditPostModel
    {
        public string AuthorId { get; set; }
        int CategoryId { get; set; }
        string Content { get; set; }
        int PostId { get; set; }
        string Title { get; set; }
    }
}
