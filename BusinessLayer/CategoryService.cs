using System.Collections.Generic;
using BigRoom.DataAccessLayer.UnitOfWork;
using BigRoom.Model;

namespace BigRoom.BusinessLayer
{
    public class CategoryService
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
