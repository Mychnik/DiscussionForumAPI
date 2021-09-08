using Forum.Application.Helpers;
using Forum.Application.Interfaces;
using Forum.Application.Interfaces.IModels.IComments;
using Forum.Application.Models.Comments;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(ICommentRepository commentRepository, UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _commentRepository = commentRepository;
            _userManager = userManager;
        }


        [HttpGet]
        [Route("CommentsFromPost")]
        [AllowAnonymous]
        public async Task <ActionResult<List<ICommentInPostModel>>> GetCommentsFromPost(int Postid)
        {
            var comments = await Task.Run(()=> _unitOfWork.comment.GetCommentsFromPostById(Postid));
            return comments;
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<ICommentInPostModel>> AddComent(NewCommentModel comment)
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var response = await _unitOfWork.comment.AddComment(comment, currentUserId);
            await _unitOfWork.ComlpeteAsync();
            return Ok(response);
        }


        [HttpPut]
        [Route("edit")]
        public async Task<ActionResult<ICommentInPostModel>> EditComment(EditCommentModel comment)
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            try
            {
                await _unitOfWork.comment.EditComment(comment, currentUserId);
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


        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteComent(int commentId)
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            try
            {
                await _unitOfWork.comment.DeleteComment(commentId, currentUserId);
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
