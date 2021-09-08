namespace Forum.Application.Interfaces.IModels.IComments
{
    public interface INewCommentModel
    {
        public string Content { get; set; }
        public int PostId { get; set; }
    }
}
