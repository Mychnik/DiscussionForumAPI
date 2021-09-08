using AutoMapper;
using Forum.Application.Interfaces;
using Forum.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Repositories
{
  public  class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ForumDbContext _dbContext;
        private readonly IMapper _mapper;
        public UnitOfWork(ForumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            category = new CategoryRepository(_dbContext, _mapper);
            comment = new CommentRepository(_dbContext, _mapper);
            post = new PostRepository(_dbContext, _mapper);
        }
        public ICategoryRepository category { get; private set; }

        public ICommentRepository comment { get; private set; }

        public IPostRepository post { get; private set; }

        public async Task ComlpeteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
