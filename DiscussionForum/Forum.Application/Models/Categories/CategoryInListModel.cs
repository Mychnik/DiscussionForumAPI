using Forum.Application.Interfaces.IModels.ICategories;

namespace Forum.Application.Models.Categories
{
    public class CategoryInListModel : ICategoryInListModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
