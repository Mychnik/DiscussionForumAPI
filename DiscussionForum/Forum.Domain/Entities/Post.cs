using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Domain.Entities
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
