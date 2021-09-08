using Forum.Application.Helpers;
using Forum.Application.Interfaces;
using Forum.Application.Interfaces.IModels.ICategories;
using Forum.Application.Models.Categories;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryrepo;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(ICategoryRepository categoryrepo, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryrepo = categoryrepo;
        }


        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public async Task<ActionResult<ICategoryInListModel>> GetAllCategories()
        {
            var all = await _unitOfWork.category.GetCategoryInList();
            await _unitOfWork.ComlpeteAsync();
            //var all = await _categoryrepo.GetCategoryInList();
            return Ok(all);
        }


        [HttpGet]
        [Route("CatById")]
        [AllowAnonymous]
        public async Task<ActionResult<ICategoryInListModel>> GetCategoryById(int id)
        {
            var result = await _unitOfWork.category.GetByIdAsync(id);
            return Ok(result);
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> CreateCategory([FromBody] NewCategoryModel newCategory)
        {
            await _unitOfWork.category.AddCategory(newCategory);
            return Ok();
        }


        [HttpPut]
        [Route("edit")]
        public async Task<ActionResult> EditCategory([FromBody] NewCategoryModel editedCategory)
        {
            await _unitOfWork.category.EditCategory(editedCategory);
            return Ok();
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _unitOfWork.category.AdminCategoryDelete(id);
            return Ok();
        }
    }
}
