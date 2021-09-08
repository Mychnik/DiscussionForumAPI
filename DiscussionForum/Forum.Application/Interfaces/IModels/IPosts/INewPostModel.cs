namespace Forum.Application.Interfaces.IModels
{
    public interface INewPostModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
    }
}
