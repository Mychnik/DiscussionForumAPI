//using Forum.Application.Interfaces;
//using Forum.Domain.Entities;
//using Shouldly;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace Forum.Tests.Categories
//{
//   public class GetCategoryByIdTest
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        public GetCategoryByIdTest(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        [Fact]
//        public async Task GotCategoryById ()
//        {
//            var categoryToFind = new Category
//            {
//                CategoryId = 99,
//                Name = "Find Me"
//            };
//            await _unitOfWork.category.AddAsync(categoryToFind);
//            await _unitOfWork.ComlpeteAsync();
//            var category = await _unitOfWork.category.GetByIdAsync(categoryToFind.CategoryId);
//            category.CategoryId.ShouldBe(categoryToFind.CategoryId);
//            category.Name.ShouldBe(categoryToFind.Name);
//        }
//    }
//}
