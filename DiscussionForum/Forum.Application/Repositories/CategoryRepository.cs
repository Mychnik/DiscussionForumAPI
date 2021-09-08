using AutoMapper;
using Forum.Application.Interfaces;
using Forum.Application.Interfaces.IModels.ICategories;
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
  public  class CategoryRepository : AsyncRepository<Category>, ICategoryRepository
    {
        private readonly IMapper _mapper;
        public CategoryRepository(ForumDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }


        public async Task<Category> GetCategoriesWithPosts(int id)
        {
            var result = _dbcontext.Categories.Include(p => p.Posts).SingleOrDefaultAsync(i => i.CategoryId == id);
            return await result; //Chyba dobrze!!!!
        }

        public async Task<List<ICategoryInListModel>> GetCategoryInList()
        {
            var result = await GetAllAsync();
            return _mapper.Map<List<ICategoryInListModel>>(result);
        }

        public async Task EditCategory(INewCategoryModel passsedData)
        {
            var result = _mapper.Map<Category>(passsedData);
            
            await EditAsync(result);
        }

        public async Task<Category> AddCategory(INewCategoryModel newData)
        {
            
            var result = _mapper.Map<Category>(newData);
            await AddAsync(result);
            return result;
        }
        public async Task AdminCategoryDelete(int id)
        {
            var category = _dbcontext.Categories.FirstOrDefault<Category>(x => x.CategoryId == id);
            await DeleteAsync(category);
        }

        public async Task<ICategoryInListModel> GetCategoryById(int id)
        {
            var result = await _dbcontext.Categories.SingleOrDefaultAsync(a=>a.CategoryId==id);
            return _mapper.Map<ICategoryInListModel>(result);
        }
    }
}
