using Forum.Application.Interfaces;
using Forum.Application.Interfaces.IModels.ICategories;
using Forum.Application.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Moq;

namespace Forum.Tests.Categories
{
    public class AddCategoryTest
    {
        private readonly Mock<IUnitOfWork> _mockUnit;
        public AddCategoryTest()
        {
            _mockUnit = RepositoryMock.GetUnitOfWorkMock();
            //_unitOfWork = unitOfWork; IUnitOfWork unitOfWork
        }
        //[Fact]
        //public async Task AddedCategory()
        //{

        //    var categories = await _mockUnit.Object.category.GetAllAsync();
        //    var allCategoriesCount = categories.Count();
        //    var newCategory = new NewCategoryModel
        //    {
        //        Name = "KategoriaTestowa"
        //    };
        //    var response = await _unitOfWork.category.AddCategory(newCategory);
        //    await _unitOfWork.ComlpeteAsync();
        //    var allCategoriesAfterTest = await _unitOfWork.category.GetAllAsync();


        //    allCategoriesAfterTest.Count.ShouldBe(allCategoriesCount + 1);

        //}
    }
}
