using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Interfaces
{
   public interface IAsyncRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task EditAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
