using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BigRoom.BusinessLayer;
using BigRoom.Service.Common;
using BigRoom.Service.Models;

namespace BigRoom.Service.Controllers
{
    public class CategoriesController : BaseApiController
    {
        CategoryService categoryService = new CategoryService();

        public IEnumerable<CategoryVM> Get()
        {
            return categoryService.GetCategories().Select(c => new CategoryVM
            {
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

        protected override void Dispose(bool disposing)
        {
            categoryService.Dispose();
            base.Dispose(disposing);
        }
    }
}
