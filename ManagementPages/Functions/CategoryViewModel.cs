using System;
using System.Collections.Generic;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class CategoryViewModel : ICategoryViewModel
    {
        private DbService _dbService;

        public List<IPostViewModel> Posts = new();

        public CategoryViewModel(DbService dbService, int categoryId)
        {
            _dbService = dbService;
            GetCategoryData(categoryId);
            GetPosts(categoryId);
        }

        public Category CategoryModel { get; set; }

        public void GetCategoryData(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void GetPosts(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}