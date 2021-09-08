//using Forum.Application.Interfaces;
//using Forum.Application.Models.Categories;
//using Shouldly;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace Forum.Tests.Categories
//{
//   public class AdminCategoryDeleteTest
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        public AdminCategoryDeleteTest(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        [Fact]
//        public async Task DeletedCategory()
//        {
//            var newCategory = new NewCategoryModel
//            {

//                Name = "Kategoria do kasowania"
//            };
//            var addCateogryToDelete = await _unitOfWork.category.AddCategory(newCategory);
//            await _unitOfWork.ComlpeteAsync();

//            var categories = await _unitOfWork.category.GetAllAsync();
//            var allCategoriesCount = categories.Count();

//            await _unitOfWork.category.AdminCategoryDelete(addCateogryToDelete.CategoryId);
//            await _unitOfWork.ComlpeteAsync();

//            var allCategoriesAfterTest = await _unitOfWork.category.GetAllAsync();


//            allCategoriesAfterTest.Count.ShouldBe(allCategoriesCount - 1);

//        }
//    }
//}
