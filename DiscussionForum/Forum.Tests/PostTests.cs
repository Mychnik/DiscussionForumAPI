using Forum.Application.Models.Posts;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Forum.Tests
{
    public class PostTests
    {
        private ArrangeTest arrange;
        private int typeOfDB = 2;
        public PostTests()
        {
            arrange = new ArrangeTest();
        }


        [Fact]
        public async Task ShouldReturnPostsFromSpecifedCategory()
        {
            //Arrange
            var unitOfWork = arrange.ArrangeUnitOfWork("postsAndCategory",typeOfDB);

            //Arc
            var postsFromCategory = await unitOfWork.post.GetPostsFromSpecfiedCategory(1);

            //Assert
            postsFromCategory.ShouldNotBeNull();
            //postsFromCategory.ShouldBeOfType<List<IPostInListModel>>();
        }

        [Fact]
        public async Task ShouldGetPostWithComments()
        {
            //Arrange
            var unitOfWork = arrange.ArrangeUnitOfWork("postWithComments", typeOfDB);

            //Arc
            var postWithComments = await unitOfWork.post.GetPostWithCommets(7);

            //Assert
            postWithComments.Comments.ShouldNotBeNull();


        }

        [Fact]
        public async Task ShouldAddNewPost()
        {
            //Arrange
            var unitOfWork = arrange.ArrangeUnitOfWork("addNewPost", typeOfDB);

            //Arc
            var countPosts = await unitOfWork.post.GetPostsFromSpecfiedCategory(1);
            var newPost = new NewPostModel { Title = "ExampleTitle", Content = "ExampleContent", CategoryId = 1 };
            await unitOfWork.post.AddPost(newPost, "currentUserId");
            await unitOfWork.ComlpeteAsync();
            var postsAfterAdd = await unitOfWork.post.GetPostsFromSpecfiedCategory(1);
            var countPostsAfterAdd = postsAfterAdd.Count;

            //Assert
            countPostsAfterAdd.ShouldBe(countPosts.Count + 1);
        }

        [Fact]
        public async Task ShouldDeletePost()
        {
            //Arrange
            var unitOfWork = arrange.ArrangeUnitOfWork("deletePost", typeOfDB);

            //Arc
            var posts = await unitOfWork.post.GetPostsFromSpecfiedCategory(1);
            var countPosts = posts.Count;
            await unitOfWork.post.DeletePostById(5, "aaa");
            await unitOfWork.ComlpeteAsync();
            var countPostsAfterDelete = await unitOfWork.post.GetPostsFromSpecfiedCategory(1);

            //Assert
            countPosts.ShouldBe(countPostsAfterDelete.Count + 1);
        }

        [Fact]
        public async Task ShouldChangePostCategory()
        {
            //Arrange
            var unitOfWork = arrange.ArrangeUnitOfWork("changePostCategory", typeOfDB);

            //Arc
            //post id = 8 
            int newCategoryId = 2;
            await unitOfWork.post.ChangePostCategory(8,newCategoryId);
            var postToCheck = await unitOfWork.post.GetByIdAsync(8);
            //Assert
            postToCheck.CategoryId.ShouldBe(newCategoryId);
        }
    }
}
