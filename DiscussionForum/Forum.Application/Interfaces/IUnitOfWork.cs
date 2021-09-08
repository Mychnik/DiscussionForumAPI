using System.Threading.Tasks;

namespace Forum.Application.Interfaces
{
  public  interface IUnitOfWork
    {
        ICategoryRepository category { get; }
        ICommentRepository comment { get; }
        IPostRepository post { get; }
        Task ComlpeteAsync();
    }
}
