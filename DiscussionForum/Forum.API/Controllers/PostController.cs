using Forum.Application.Helpers;
using Forum.Application.Interfaces;
using Forum.Application.Interfaces.IModels;
using Forum.Application.Models.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = IdentityConstantHelper.UsersRoleConstans)]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _postRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public PostController(IPostRepository postRepository,
                              UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
            _userManager = userManager;
        }


        [HttpGet]
        [Route("allFromCategory")]
        [AllowAnonymous]
        public async Task<ActionResult<List<IPostInListModel>>> GetPostByCategory(int Categoryid)
        {
            var all = await _unitOfWork.post.GetPostsFromSpecfiedCategory(Categoryid);
            return Ok(all);
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<IPostInListModel>> AddNewPost([FromBody] NewPostModel newPost)
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);

            var result = await _unitOfWork.post.AddPost(newPost, currentUserId);
            await _unitOfWork.ComlpeteAsync();
            return Ok(result);
        }


        [HttpPut]
        [Route("edit")]
        public async Task<ActionResult> UpdatePost([FromBody] EditPostModel UpdatedPost)
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            try
            {
                await _unitOfWork.post.EditPost(UpdatedPost, currentUserId);
                await _unitOfWork.ComlpeteAsync();
                return Ok();
            }
            catch (Exception x)
            {
                if (x.HResult == 401)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, x.Message);
                }
                throw;
            }

        }
        [HttpPut]
        [Route("changeCategory")]
        [Authorize(Roles = IdentityConstantHelper.AdminRoleConstans)]
        public async Task<ActionResult> ChangePostCategory(int PostId, int newCategoryId)
        {
            var postId = await _unitOfWork.post.ChangePostCategory(PostId, newCategoryId);
            await _unitOfWork.ComlpeteAsync();
            return Ok(postId);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeletePost(int Postid)
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            try
            {
                await _unitOfWork.post.DeletePostById(Postid, currentUserId);
                await _unitOfWork.ComlpeteAsync();
                return Ok();
            }
            catch (Exception x)
            {
                if (x.HResult == 401)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, x.Message);
                }
                throw;
            }

        }
    }
}
