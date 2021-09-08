using Forum.Application.Interfaces;
using Forum.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Repositories
{
  public  class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ForumDbContext _dbcontext;
        public AsyncRepository(ForumDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbcontext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => _dbcontext.Set<T>().Remove(entity));            
        }

        public async Task EditAsync(T entity)
        {
            await Task.Run(() => _dbcontext.Entry(entity).State = EntityState.Modified);           
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }
    }
}
