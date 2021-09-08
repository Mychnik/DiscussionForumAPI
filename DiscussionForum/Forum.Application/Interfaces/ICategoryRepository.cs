using Forum.Application.Interfaces.IModels.ICategories;
using Forum.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Interfaces
{
  public  interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<Category> GetCategoriesWithPosts(int id);
        Task<ICategoryInListModel> GetCategoryById(int id);
        Task<List<ICategoryInListModel>> GetCategoryInList();
       Task EditCategory(INewCategoryModel passedData);
        Task<Category> AddCategory(INewCategoryModel newData);
        Task AdminCategoryDelete(int categoryId);
    }
}
