using Forum.Application.Interfaces.IModels.IComments;
using Forum.Application.Models.Comments;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Forum.Tests
{
   public class CommentTests
    {
        private ArrangeTest arrange;
        private int typeOfDB = 3;
        public CommentTests()
        {
            arrange = new ArrangeTest();
        }
         [Fact]
         public async Task ShouldGetPostWithComments ()
        {
            //Arrange
            var unitOfWork = arrange.ArrangeUnitOfWork("getCommentsFromPost",typeOfDB);


            //Arc
            var commentsWithPost = await unitOfWork.comment.GetCommentsFromPostById(5);


            //Assert
            commentsWithPost.ShouldNotBeNull();
            commentsWithPost.ShouldBeOfType<List<ICommentInPostModel>>();
        }

        [Fact]
        public async Task ShouldAddComment()
        {
            //Arrange
            var unitOfWork = arrange.ArrangeUnitOfWork("addComment", typeOfDB);


            //Arc
            var newComment = new NewCommentModel { Content = "newCommentExampleContent", PostId = 5 };
            var comments = await unitOfWork.comment.GetCommentsFromPostById(5);
            var countComments = comments.Count();
            await unitOfWork.comment.AddComment(newComment, "exampleUserId");
            await unitOfWork.ComlpeteAsync();
            var commentCountAfterAdd = await unitOfWork.comment.GetCommentsFromPostById(5);


            //Assert
            countComments.ShouldBe(commentCountAfterAdd.Count - 1);
           

        }
        [Fact]
        public async Task ShouldEditComment()
        {
            //Arrange
            var unitOfWork = arrange.ArrangeUnitOfWork("editComment", typeOfDB);


            //Arc
            var oldComment = await unitOfWork.comment.GetCommentById(11);
            string oldContent = oldComment.Content;
            int oldCommentId = oldComment.CommentId;
            var newComment = new EditCommentModel {AuthorId=oldComment.AuthorId, Content="BrandNewCommentContent", commentId=oldComment.CommentId};
            await unitOfWork.comment.EditComment(newComment, oldComment.AuthorId);
            await unitOfWork.ComlpeteAsync();
            var commentAfterEdit = await unitOfWork.comment.GetCommentById(11);


            //Assert
            oldComment.Content.ShouldNotBe(oldContent);
            oldComment.CommentId.ShouldBe(oldCommentId);
            

        }
        [Fact]
        public async Task ShouldDeleteComment()
        {
            //Arrange
            var unitOfWork = arrange.ArrangeUnitOfWork("deleteComment", typeOfDB);


            //Arc
            var comments = await unitOfWork.comment.GetCommentsFromPostById(5);
            var count = comments.Count();
            await unitOfWork.comment.DeleteComment(11,"aaa");
            await unitOfWork.ComlpeteAsync();
            var commentCountAfterDelete = await unitOfWork.comment.GetCommentsFromPostById(5);


            //Assert
            count.ShouldBe(commentCountAfterDelete.Count + 1);

        }
    }
}
