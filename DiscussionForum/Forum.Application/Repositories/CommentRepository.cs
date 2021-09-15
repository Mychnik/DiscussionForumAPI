using AutoMapper;
using Forum.Application.Exceptions;
using Forum.Application.Interfaces;
using Forum.Application.Interfaces.IModels.IComments;
using Forum.Domain.Entities;
using Forum.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Repositories
{
   public class CommentRepository : AsyncRepository<Comment> , ICommentRepository
    {
        private readonly IMapper _mapper;
        public CommentRepository(ForumDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
        public async Task<Comment> GetCommentById(int id)
        {
            var result = await _dbcontext.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
            return result;


        }
        public async Task<List<ICommentInPostModel>> GetCommentsFromPostById(int id)
        {
            var result = _dbcontext.Comments.Where(p => p.PostId == id).ToList();
            return await Task.Run(()=>_mapper.Map<List<ICommentInPostModel>>(result));
        }
        public async Task<int> AddComment(INewCommentModel newComment, string currentUserId)
        {

            var result = _mapper.Map<Comment>(newComment);
            result.Date = DateTime.Now;
            await AddAsync(result);
            return result.CommentId;
        }
        public async Task<int> EditComment(IEditCommentModel edit, string currentUserId)
        {
            if (edit.AuthorId != currentUserId) throw new UserIsNotTheOwnerException("Nie jesteś właścicielem komentarza");
            //var result = _mapper.Map<Comment>(edit);
            var result = await _dbcontext.Comments.FindAsync(edit.commentId);
            result.Content = edit.Content;
            result.Date = DateTime.Now;
            await EditAsync(result);
            return result.CommentId;
        }
        public async Task DeleteComment(int commentId, string currentUserId)
        {
            var comment = await _dbcontext.Comments.FirstOrDefaultAsync(x => x.CommentId == commentId);
            if (comment.AuthorId != currentUserId) throw new UserIsNotTheOwnerException("Nie jesteś właścicielem komentarza");
            await DeleteAsync(comment);
        }

        public async Task AdminCommentDelete(int commentId)
        {
            var commentToDelete = _dbcontext.Comments.FirstOrDefault(x => x.CommentId == commentId);
            await DeleteAsync(commentToDelete);
        }
    }
}
