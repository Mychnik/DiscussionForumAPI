using Forum.Application.Interfaces.IModels.ICategories;

namespace Forum.Application.Models.Categories
{
   public class NewCategoryModel : INewCategoryModel
    {
        public string Name { get; set; }
    }
}
