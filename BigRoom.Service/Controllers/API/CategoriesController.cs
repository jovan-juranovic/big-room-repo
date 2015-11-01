using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.BusinessLayer.Services;
using BigRoom.BusinessLayer.Util;
using BigRoom.Model;
using BigRoom.Service.Common;
using BigRoom.Service.Models.CategoryVms;

namespace BigRoom.Service.Controllers.API
{
    public class CategoriesController : BaseApiController
    {
        #region Fields

        private readonly ICategoryService categoryService;

        #endregion

        #region Ctor's

        public CategoriesController()
        {
            this.categoryService = new CategoryService();
        }

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        #endregion

        #region API

        public IEnumerable<CategoryVM> Get()
        {
            return GetCategories();
        }

        [Authorize]
        public CategoryVM Get(int id)
        {
            Category category = categoryService.FindCategory(id);
            return new CategoryVM
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public IHttpActionResult Post(CategoryVM request)
        {
            if (request.Name.IsNullOrEmpty())
            {
                return this.BadRequest("Category name must be supplied.");
            }

            Category category = new Category
            {
                Name = request.Name
            };

            if (this.categoryService.CreateCategory(category))
            {
                List<CategoryVM> categories = GetCategories();
                return this.Created(categories);
            }

            return this.BadRequest();
        }

        public IHttpActionResult Put(CategoryVM request)
        {
            if (request.Name.IsNullOrEmpty() && request.Id < 1)
            {
                return this.BadRequest("Category not valid.");
            }

            Category category = this.categoryService.FindCategory(request.Id);
            if (category == null)
            {
                return this.NotFound();
            }

            category.Name = request.Name;

            if (this.categoryService.EditCategory(category))
            {
                List<CategoryVM> categories = GetCategories();
                return this.Ok(categories);
            }

            return this.BadRequest();
        }

        public IHttpActionResult Delete(int id)
        {
            Category category = this.categoryService.FindCategory(id);
            if (category == null)
            {
                return this.NotFound();
            }

            if (this.categoryService.DeleteCategory(id))
            {
                List<CategoryVM> categories = GetCategories();
                return this.Ok(categories);
            }

            return this.BadRequest();
        }

        #endregion

        private List<CategoryVM> GetCategories()
        {
            return categoryService.GetCategories().Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }
    }
}
