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

        public Category FindCategory(int id)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.CategoryRepository.Find(id);
            }
        }

        public bool CreateCategory(Category category)
        {
            using (var uow = new UnitOfWork())
            {
                uow.CategoryRepository.Insert(category);
                return uow.Save() == 1;
            }
        }

        public bool EditCategory(Category category)
        {
            using (var uow = new UnitOfWork())
            {
                uow.CategoryRepository.Update(category);
                return uow.Save() > 0;
            }
        }

        public bool DeleteCategory(int id)
        {
            using (var uow = new UnitOfWork())
            {
                uow.CategoryRepository.Delete(id);
                return uow.Save() > 0;
            }
        }
    }
}
