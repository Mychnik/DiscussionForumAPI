﻿using Forum.Application.Interfaces.IModels.IComments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Interfaces
{
  public  interface ICommentRepository
    {
        Task<List<ICommentInPostModel>> GetCommentsFromPostById(int id);
        Task<int> AddComment(INewCommentModel comment, string currentUserId);
        Task<int> EditComment(IEditCommentModel edit, string currentUserId);
        Task DeleteComment(int Commentid, string currentUserId);
        Task AdminCommentDelete(int CommentId);
    }
}
