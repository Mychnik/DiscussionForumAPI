using Forum.Application.Interfaces;
using Forum.Application.Interfaces.IModels.ICategories;
using Forum.Application.Models.Categories;
using Forum.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Tests
{
   public class RepositoryMock
    {
        public static Mock<IUnitOfWork> GetUnitOfWorkMock()
        {
            var dummyCategories = GetDummyCategories();

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            //Mocks
            mockUnitOfWork.Setup(m => m.category.GetAllAsync()).ReturnsAsync(dummyCategories);
            mockUnitOfWork.Setup(m => m.category.AddCategory(It.IsAny<NewCategoryModel>())).ReturnsAsync(It.IsAny<Category>);

            
            
            return mockUnitOfWork;
        }
        private static List<Category> GetDummyCategories()
        {
            Category cat1 = new Category()
            {
                CategoryId = 1,
                Name = "Category1"
            };
            Category cat2 = new Category()
            {
                CategoryId = 2,
                Name = "Category2"
            };
            Category cat3 = new Category()
            {
                CategoryId = 3,
                Name = "Category3"
            };
            Category cat4 = new Category()
            {
                CategoryId = 4,
                Name = "Category4"
            };
            Category cat5 = new Category()
            {
                CategoryId = 5,
                Name = "Category5"
            };
            List<Category> li = new List<Category>();
            li.Add(cat1);
            li.Add(cat2);
            li.Add(cat3);
            li.Add(cat4);
            li.Add(cat5);
            return li;

        }
    }
}
