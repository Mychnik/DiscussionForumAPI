using Forum.Application.Interfaces.IModels;
using Forum.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Interfaces
{
   public interface IPostRepository : IAsyncRepository<Post>
    {
        Task<Post> GetPostWithCommets(int id);
        Task<List<IPostInListModel>> GetPostsFromSpecfiedCategory(int id);
        Task DeletePostById(int Postid, string currentUserId);
        Task<int> EditPost(IEditPostModel newPost, string currentUserId);
        Task<int> AddPost(INewPostModel newPost, string currentUserId);
        Task<int> ChangePostCategory(int PostId, int newCategoryId);
        Task AdminPostDelete(int postId);
    }
}
