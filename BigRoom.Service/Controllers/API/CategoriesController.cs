﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.BusinessLayer.Services;
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
            return categoryService.GetCategories().Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        public string Get(int id)
        {
            return "value";
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }

        #endregion
    }
}