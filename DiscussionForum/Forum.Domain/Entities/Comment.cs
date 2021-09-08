using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }


        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
