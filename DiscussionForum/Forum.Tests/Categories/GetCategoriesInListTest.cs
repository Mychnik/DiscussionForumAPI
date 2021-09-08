using Forum.Application.Interfaces;
using Forum.Application.Interfaces.IModels.ICategories;
using Forum.Application.Models.Categories;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Forum.Tests.Categories
{
   public class GetCategoriesInListTest
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly Mock<IUnitOfWork> _mockUnit;
        public GetCategoriesInListTest()
        {
            _mockUnit=RepositoryMock.GetUnitOfWorkMock();
            //_unitOfWork = unitOfWork; IUnitOfWork unitOfWork
        }
        [Fact]
        public async Task ListedCategories()
        {
            var listedCategories = await  _mockUnit.Object.category.GetAllAsync();
            //listedCategories.ShouldBeOfType<List<ICategoryInListModel>>();
            listedCategories.ShouldNotBeNull();
            //pogczampik
        }
    }
}
