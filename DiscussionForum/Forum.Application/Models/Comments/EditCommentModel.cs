﻿using Forum.Application.Interfaces.IModels.IComments;

namespace Forum.Application.Models.Comments
{
   public class EditCommentModel : IEditCommentModel
    {
        public string AuthorId { get; set; }
        public string Content { get; set; }
    }
}
