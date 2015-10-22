using System.Collections.Generic;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category FindCategory(int id);
    }
}