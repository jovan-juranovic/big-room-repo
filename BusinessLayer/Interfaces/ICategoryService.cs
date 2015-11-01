using System.Collections.Generic;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category FindCategory(int id);
        bool CreateCategory(Category category);
        bool EditCategory(Category category);
        bool DeleteCategory(int id);
    }
}