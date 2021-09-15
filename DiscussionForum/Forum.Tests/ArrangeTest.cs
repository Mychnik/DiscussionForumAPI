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
        public IUnitOfWork ArrangeUnitOfWork(string dbName, int dbType)
        {
            //ArrangeMapper
            var configurationProvider = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = configurationProvider.CreateMapper();


            //Arrange DbContext
            var options = new DbContextOptionsBuilder<ForumDbContext>().UseInMemoryDatabase(databaseName: dbName).Options;
            var context = new ForumDbContext(options);
            Seed(context,dbType);

            //Arrange UnitOfWork
            var unitOfWork = new UnitOfWork(context, mapper);

            return unitOfWork;
        }



        private void Seed(ForumDbContext context, int dbType)
        {
            //var dataBase = new[]
            //{
            //    new Category{CategoryId=1 ,Name = "TestCategory1", Posts = new[]
            //{
            //        new Post{PostId = 1, AuthorId = "aaa", Title = "PostNumber1", Content ="ExampleContent", Date = new DateTime(2001,12,21),CategoryId=1},
            //        new Post{PostId = 2, AuthorId = "bbb", Title = "PostNumber2", Content ="ExampleContent2", Date = new DateTime(2005,08,14),CategoryId=1},
            //        new Post{PostId = 3, AuthorId = "ccc", Title = "PostNumber3", Content ="ExampleContent3", Date = new DateTime(2021,05,27),CategoryId=1},
            //        new Post{PostId = 4, AuthorId = "ddd", Title = "PostNumber4", Content ="ExampleContent4", Date = new DateTime(2050,02,01),CategoryId=1, Comments = new[]
            //    {
            //            new Comment{CommentId = 1, AuthorId ="aaa", Content="CommentContent", Date = new DateTime(2004,06,02)},
            //            new Comment{CommentId = 2, AuthorId ="bbb", Content="CommentContent", Date = new DateTime(2006,04,01) },
            //            new Comment{CommentId = 3, AuthorId ="ccc", Content="CommentContent", Date = new DateTime(2007,02,08) },
            //            new Comment{CommentId = 4, AuthorId ="ddd", Content="CommentContent", Date = new DateTime(2008,03,02) },
            //            new Comment{CommentId = 5, AuthorId ="eee", Content="CommentContent", Date = new DateTime(1996,04,02) }

            //    }},
            //}},
            //    new Category{CategoryId=2,Name = "TestCategory2" },
            //    new Category{CategoryId=3,Name = "TestCategory3" },
            //    new Category{CategoryId=4,Name = "TestCategory4" },
            //    new Category{CategoryId=5,Name = "TestCategory5" }
            //};


            var categoryDataBase = new[]
            {
                new Category{CategoryId=1 ,Name = "TestCategory1", Posts = new[]
            {
                    new Post{PostId = 1, AuthorId = "aaa", Title = "PostNumber1", Content ="ExampleContent", Date = new DateTime(2001,12,21),CategoryId=1},
                    new Post{PostId = 2, AuthorId = "bbb", Title = "PostNumber2", Content ="ExampleContent2", Date = new DateTime(2005,08,14),CategoryId=1},
                    new Post{PostId = 3, AuthorId = "ccc", Title = "PostNumber3", Content ="ExampleContent3", Date = new DateTime(2021,05,27),CategoryId=1},
                    new Post{PostId = 4, AuthorId = "ddd", Title = "PostNumber4", Content ="ExampleContent4", Date = new DateTime(2050,02,01),CategoryId=1, Comments = new[]
                {
                        new Comment{CommentId = 1, AuthorId ="aaa", Content="CommentContent", Date = new DateTime(2004,06,02)},
                        new Comment{CommentId = 2, AuthorId ="bbb", Content="CommentContent", Date = new DateTime(2006,04,01) },
                        new Comment{CommentId = 3, AuthorId ="ccc", Content="CommentContent", Date = new DateTime(2007,02,08) },
                        new Comment{CommentId = 4, AuthorId ="ddd", Content="CommentContent", Date = new DateTime(2008,03,02) },
                        new Comment{CommentId = 5, AuthorId ="eee", Content="CommentContent", Date = new DateTime(1996,04,02) }

                }},
            }},
                new Category{CategoryId=2,Name = "TestCategory2" },
                new Category{CategoryId=3,Name = "TestCategory3" },
                new Category{CategoryId=4,Name = "TestCategory4" },
                new Category{CategoryId=5,Name = "TestCategory5" }


            };

            var postsDataBase = new[]
            {
                    new Post{PostId = 5, AuthorId = "aaa", Title = "PostNumber1", Content ="ExampleContent", Date = new DateTime(2001,12,21),CategoryId=1},
                    new Post{PostId = 6, AuthorId = "bbb", Title = "PostNumber2", Content ="ExampleContent2", Date = new DateTime(2005,08,14),CategoryId=1},
                    new Post{PostId = 7, AuthorId = "ccc", Title = "PostNumber3", Content ="ExampleContent3", Date = new DateTime(2021,05,27),CategoryId=1},
                    new Post{PostId = 8, AuthorId = "ddd", Title = "PostNumber4", Content ="ExampleContent4", Date = new DateTime(2050,02,01),CategoryId=1},
                    new Post{PostId = 9, AuthorId = "ddd", Title = "PostNumber4", Content ="ExampleContent4", Date = new DateTime(2050,02,01),CategoryId=1, Comments = new[]
                {
                        new Comment{CommentId = 6, AuthorId ="aaa", Content="CommentContent", Date = new DateTime(2004,06,02)},
                        new Comment{CommentId = 7, AuthorId ="bbb", Content="CommentContent", Date = new DateTime(2006,04,01) },
                        new Comment{CommentId = 8, AuthorId ="ccc", Content="CommentContent", Date = new DateTime(2007,02,08) },
                        new Comment{CommentId = 9, AuthorId ="ddd", Content="CommentContent", Date = new DateTime(2008,03,02) },
                        new Comment{CommentId = 10, AuthorId ="eee", Content="CommentContent", Date = new DateTime(1996,04,02) }

                }},
            };

            var commentDataBase = new[]
            {
                        new Comment{CommentId = 11, AuthorId ="aaa", Content="CommentContentFirst", Date = new DateTime(2004,06,02),PostId =5 },
                        new Comment{CommentId = 12, AuthorId ="bbb", Content="CommentContent", Date = new DateTime(2006,04,01),PostId =5 },
                        new Comment{CommentId = 13, AuthorId ="ccc", Content="CommentContent", Date = new DateTime(2007,02,08),PostId =5 },
                        new Comment{CommentId = 14, AuthorId ="ddd", Content="CommentContent", Date = new DateTime(2008,03,02),PostId =5 },
                        new Comment{CommentId = 15, AuthorId ="eee", Content="CommentContent", Date = new DateTime(1996,04,02),PostId =5 }
            };

            //var posts = new[]
            //{
            //    new Post{PostId = 1, AuthorId = "aaa", Title = "PostNumber1", Content ="ExampleContent", Date = new DateTime(2001,05,21)}
            //};

            if(dbType==1)
            context.Categories.AddRange(categoryDataBase);
            else if(dbType==2)
            context.Posts.AddRange(postsDataBase);
            else if(dbType==3)
            context.Comments.AddRange(commentDataBase);


            context.SaveChanges();
            
        }
    }
}
