using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class CategoryViewModel : ICategoryViewModel
    {
        public List<IPostViewModel> Posts { get; set; } = new();

        public CategoryViewModel(int categoryId)
        {
            GetCategoryData(categoryId);
            GetPosts(categoryId);
        }

        public CategoryViewModel()
        {
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

        public async Task AddNewPost(Post newPost, int categoryId, bool isPublished, IDbService dbService)
        {
            Post postModel = new Post
            {
                Title = newPost.Title,
                CategoryId = categoryId,
                Text = newPost.Text,
                Author = newPost.Author,
                IsPublished = isPublished
            };

            string sql = @"insert into Post (Title, CategoryId, Text, Author, IsPublished)
                values (@Title, @CategoryId, @Text, @Author, @IsPublished);";

            await dbService.SaveData(sql, postModel);

            IPostViewModel newPostAdded = new PostViewModel();
            newPostAdded.PostModel = postModel;

            Posts.Add(newPostAdded);
        }

        public async Task EditCategory(int categoryModelCategoryId, IDbService dbService)
        {
            string sql = $"update Category set Title = \"{CategoryModel.Title}\" where CategoryId = {CategoryModel.CategoryId}";

            await dbService.SaveData(sql, CategoryModel);
        }

        public async Task DeleteCategory(IDbService dbService) // virker ikke på nyoprettede kategorier, fordi de ikke har et ID. Se hvordan det er lavet med posts (re-fetcher posts i callback)
        {
            string sql = $"delete from Category where CategoryId = {CategoryModel.CategoryId}";

            await dbService.SaveData(sql, CategoryModel);
        }
    }
}