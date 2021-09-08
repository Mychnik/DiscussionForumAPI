using AutoMapper;
using Forum.Application.Exceptions;
using Forum.Application.Interfaces;
using Forum.Application.Interfaces.IModels;
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
   public class PostRepository : AsyncRepository<Post> ,IPostRepository
    {
        private readonly IMapper _mapper;

        public PostRepository(ForumDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }


        public async Task<List<IPostInListModel>> GetPostsFromSpecfiedCategory(int id)
        {
            var post = await GetAllAsync();
            var filtered = post.Where(x => x.CategoryId == id).ToList();

            return _mapper.Map<List<IPostInListModel>>(filtered);
        }


        public async Task<Post> GetPostWithCommets(int id)
        {
            var result = _dbcontext.Posts.Include(c => c.Comments).FirstOrDefaultAsync(i => i.PostId == id);

            return await result;
        }


        public async Task<int> AddPost(INewPostModel newPost, string currentUserId)
        {
            var mappedNewPost = _mapper.Map<Post>(newPost);
            mappedNewPost.Date = DateTime.Now;
            mappedNewPost.AuthorId = currentUserId;
            var response = await AddAsync(mappedNewPost);
            return response.PostId;
        }


        public async Task<int> EditPost(IEditPostModel newPost, string currentUserId)
        {
            //var oldPost=_dbcontext.Posts.FirstOrDefault
            if (newPost.AuthorId != currentUserId) throw new UserIsNotTheOwnerException("Nie jesteś właścicielem postu");
            var mappedEditedPost = _mapper.Map<Post>(newPost);
            mappedEditedPost.Date = DateTime.Now;
            await EditAsync(mappedEditedPost);
            return mappedEditedPost.PostId;
        }


        public async Task DeletePostById(int Postid, string currentUserId)
        {
            var PostToDelete = await _dbcontext.Posts.FirstOrDefaultAsync(x => x.PostId == Postid);
            if (PostToDelete.AuthorId != currentUserId) throw new UserIsNotTheOwnerException("Nie jesteś właścicielem postu");
            await DeleteAsync(PostToDelete);
        }

        public async Task<int> ChangePostCategory(int postId, int newCategoryId)
        {
            var postToTransfer = await _dbcontext.Posts.FirstOrDefaultAsync(x => x.PostId == postId);
            postToTransfer.CategoryId = newCategoryId;
            await EditAsync(postToTransfer);
            return postId;
        }

        public async Task AdminPostDelete(int postId)
        {
            var postToDelete = await _dbcontext.Posts.FirstOrDefaultAsync(x => x.PostId == postId);
            await DeleteAsync(postToDelete);
        }
    }
}
