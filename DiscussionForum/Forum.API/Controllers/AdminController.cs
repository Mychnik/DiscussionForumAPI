using Forum.Application.Helpers;
using Forum.Application.Interfaces;
using Forum.Application.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = IdentityConstantHelper.AdminRoleConstans)]
    public class AdminController : ControllerBase
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }
        [HttpDelete]
        [Route("deleteCategory")]
        public async Task<ActionResult> DeleteCategory(int categoryId)
        {
            await _unitOfWork.category.AdminCategoryDelete(categoryId);
            await _unitOfWork.ComlpeteAsync();
         
            return Ok();
        }
        [HttpDelete]
        [Route("deleteComment")]
        public async Task<ActionResult> DeleteComment(int commentId)
        {
            
            await _unitOfWork.comment.AdminCommentDelete(commentId);
            await _unitOfWork.ComlpeteAsync();
            return Ok();
        }
        [HttpDelete]
        [Route("deletePost")]
        public async Task<ActionResult> DeletePost(int postId)
        {
            await _unitOfWork.post.AdminPostDelete(postId);
            await _unitOfWork.ComlpeteAsync();
          
            return Ok();
        }

    }
}
