//using Forum.Application.Interfaces;
//using Shouldly;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace Forum.Tests.Categories
//{
//   public class GetCategoryWithPostsTest
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        public GetCategoryWithPostsTest(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        [Fact]
//        public async Task GotCategoryWithPosts ()
//        {
//            var categoryWithPosts = await _unitOfWork.category.GetCategoriesWithPosts(1);
//            categoryWithPosts.ShouldNotBeNull();
//        }
//    }
//}
