using System.Collections.Generic;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.DataAccessLayer.UnitOfWork;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Services
{
    public class CategoryService : ICategoryService
    {
        public IEnumerable<Category> GetCategories()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.CategoryRepository.GetAll();
            }
        }
    }
}
