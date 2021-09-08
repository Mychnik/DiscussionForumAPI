using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
