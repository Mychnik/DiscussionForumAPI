using AutoMapper;
using Forum.Application.Interfaces.IModels;
using Forum.Application.Interfaces.IModels.ICategories;
using Forum.Application.Interfaces.IModels.IComments;
using Forum.Application.Models.Categories;
using Forum.Application.Models.Comments;
using Forum.Application.Models.Posts;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application
{
  public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //category mapping
            CreateMap<Category, CategoryInListModel>().ReverseMap();
            CreateMap<Category, ICategoryInListModel>().As<CategoryInListModel>();
            CreateMap<INewCategoryModel, Category>();

            //post mapping
            CreateMap<Post, PostInListModel>().ReverseMap();
            CreateMap<Post, IPostInListModel>().As<PostInListModel>();
            CreateMap<INewPostModel, Post>();
            CreateMap<IEditPostModel, Post>();
            
            //comment mapping
            CreateMap<Comment, CommentInPostModel>().ReverseMap();
            CreateMap<Comment, ICommentInPostModel>();
            CreateMap<INewCommentModel, Comment>();
            CreateMap<IEditCommentModel, Comment>();
        }
    }
}
