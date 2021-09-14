using AutoMapper;
using Forum.Application;
using Forum.Application.Interfaces;
using Forum.Application.Models.Categories;
using Forum.Application.Repositories;
using Forum.Domain.Entities;
using Forum.Persistence;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Forum.Tests
{
   public class CategoryTests
    {
        private ArrangeTest arrange;

        public CategoryTests()
        {
            arrange = new ArrangeTest();
        }
        [Fact]
        public async Task  ShouldListAllCategories()
        {
            // Arrange
            //var context = getFreshDB("listCategories");
            //var mapper = gethMapper();
            //Arc
            var unitOfWork = arrange.ArrangeUnitOfWork("listCategories");

            var listOfCategories = await unitOfWork.category.GetAllAsync();

            //Assert
            listOfCategories.ShouldNotBeNull();
        }

        [Fact]
        public async Task ShouldAddNewCategory()
        {
            //Arrange
            //var context = getFreshDB("addCategory");
            //var mapper = getMapper();

            //Arc
            var unitOfWork = arrange.ArrangeUnitOfWork("addCategory");
            var listOfCategories = await unitOfWork.category.GetAllAsync();
            await unitOfWork.category.AddCategory(new NewCategoryModel {Name="NewCategory"});
            await unitOfWork.ComlpeteAsync();
            var newListOfCategories = await unitOfWork.category.GetAllAsync();
            


            //Assert
            newListOfCategories.Count.ShouldBe(listOfCategories.Count + 1);
            newListOfCategories.ShouldNotBeNull();

        }
        
        [Fact]

        public async Task ShouldDeleteCategory()
        {
            //Arrange
            var unitOfWork = arrange.ArrangeUnitOfWork("deleteCategory");

            //Arc
            var listOfCategories = await unitOfWork.category.GetAllAsync();
            var categoryToDelete = await unitOfWork.category.GetByIdAsync(2);
            await unitOfWork.category.DeleteAsync(categoryToDelete);
            await unitOfWork.ComlpeteAsync();
            var reducedListOfCategories = await unitOfWork.category.GetAllAsync();


            //Assert
            reducedListOfCategories.Count.ShouldBe(listOfCategories.Count - 1);
            reducedListOfCategories.ShouldNotBeNull();

        }


        [Fact]
        public async Task ShouldGetCategoryWithPosts()
        {
            //Arrange
            //var arrange = new ArrangeTest();
            var unitOfWork = arrange.ArrangeUnitOfWork("getPosts");

            //Arc
            var categoriesWithPosts = await unitOfWork.category.GetCategoriesWithPosts(1);


            //Assert
            categoriesWithPosts.ShouldNotBeNull();
            categoriesWithPosts.Posts.ShouldNotBeNull();


        }
        
        
        
        
        
        //public IUnitOfWork ArrangeTest(string dbName)
        //{
        //    //ArrangeMapper
        //    var configurationProvider = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        //    var mapper = configurationProvider.CreateMapper();


        //    //Arrange DbContext
        //    var options = new DbContextOptionsBuilder<ForumDbContext>().UseInMemoryDatabase(databaseName: dbName).Options;
        //    var context = new ForumDbContext(options);
        //    Seed(context);

        //    //Arrange UnitOfWork
        //    var unitOfWork = new UnitOfWork(context, mapper);

        //    return unitOfWork;
        //}
        

        //public IMapper getMapper()
        //{
        //    var configurationProvider = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        //    return configurationProvider.CreateMapper();
        //}

        //public ForumDbContext  getFreshDB(string newDbName)
        //{
        //    var options = new DbContextOptionsBuilder<ForumDbContext>().UseInMemoryDatabase(databaseName: newDbName).Options;
        //    var context = new ForumDbContext(options);
        //    Seed(context);
        //    return context;
        //}

        //private void Seed(ForumDbContext context)
        //{
        //    var dataBase = new[]
        //    {
        //        new Category{CategoryId=1 ,Name = "TestCategory1", Posts = new[]
        //    {
        //        new Post{PostId = 1, AuthorId = "aaa", Title = "PostNumber1", Content ="ExampleContent", Date = new DateTime(2001,12,21)},
        //        new Post{PostId = 2, AuthorId = "bbb", Title = "PostNumber2", Content ="ExampleContent2", Date = new DateTime(2005,08,14)},
        //        new Post{PostId = 3, AuthorId = "ccc", Title = "PostNumber3", Content ="ExampleContent3", Date = new DateTime(2021,05,27)},
        //        new Post{PostId = 4, AuthorId = "ddd", Title = "PostNumber4", Content ="ExampleContent4", Date = new DateTime(2050,02,01)},
        //    }},
        //        new Category{CategoryId=2,Name = "TestCategory2" },
        //        new Category{CategoryId=3,Name = "TestCategory3" },
        //        new Category{CategoryId=4,Name = "TestCategory4" },
        //        new Category{CategoryId=5,Name = "TestCategory5" }
        //    };

        //    //var posts = new[]
        //    //{
        //    //    new Post{PostId = 1, AuthorId = "aaa", Title = "PostNumber1", Content ="ExampleContent", Date = new DateTime(2001,05,21)}
        //    //};
        //    context.Categories.AddRange(dataBase);
        //    context.SaveChanges();
        //}
    }
}
