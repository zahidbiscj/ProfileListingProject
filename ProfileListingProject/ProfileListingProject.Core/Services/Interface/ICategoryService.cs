using ProfileListingProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Services.Interface
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void AddNewCategory(Category category);
        Category GetCategory(int id);
        void EditCategory(Category category);
        void DeleteCategory(int id);
    }
}
