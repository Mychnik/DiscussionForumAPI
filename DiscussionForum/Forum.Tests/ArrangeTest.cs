using AutoMapper;
using Forum.Application;
using Forum.Application.Interfaces;
using Forum.Application.Repositories;
using Forum.Domain.Entities;
using Forum.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Tests
{
  public class ArrangeTest
    {
        public IUnitOfWork ArrangeUnitOfWork(string dbName)
        {
            //ArrangeMapper
            var configurationProvider = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = configurationProvider.CreateMapper();


            //Arrange DbContext
            var options = new DbContextOptionsBuilder<ForumDbContext>().UseInMemoryDatabase(databaseName: dbName).Options;
            var context = new ForumDbContext(options);
            Seed(context);

            //Arrange UnitOfWork
            var unitOfWork = new UnitOfWork(context, mapper);

            return unitOfWork;
        }



        private void Seed(ForumDbContext context)
        {
            var dataBase = new[]
            {
                new Category{CategoryId=1 ,Name = "TestCategory1", Posts = new[]
            {
                new Post{PostId = 1, AuthorId = "aaa", Title = "PostNumber1", Content ="ExampleContent", Date = new DateTime(2001,12,21)},
                new Post{PostId = 2, AuthorId = "bbb", Title = "PostNumber2", Content ="ExampleContent2", Date = new DateTime(2005,08,14)},
                new Post{PostId = 3, AuthorId = "ccc", Title = "PostNumber3", Content ="ExampleContent3", Date = new DateTime(2021,05,27)},
                new Post{PostId = 4, AuthorId = "ddd", Title = "PostNumber4", Content ="ExampleContent4", Date = new DateTime(2050,02,01)},
            }},
                new Category{CategoryId=2,Name = "TestCategory2" },
                new Category{CategoryId=3,Name = "TestCategory3" },
                new Category{CategoryId=4,Name = "TestCategory4" },
                new Category{CategoryId=5,Name = "TestCategory5" }
            };

            //var posts = new[]
            //{
            //    new Post{PostId = 1, AuthorId = "aaa", Title = "PostNumber1", Content ="ExampleContent", Date = new DateTime(2001,05,21)}
            //};
            context.Categories.AddRange(dataBase);
            context.SaveChanges();
        }
    }
}
