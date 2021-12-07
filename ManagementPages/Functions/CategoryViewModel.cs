using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class CategoryViewModel : ICategoryViewModel
    {
        public List<IPostViewModel> Posts { get; set; } = new();

        public CategoryModel CategoryModel { get; set; }

        public void GetCategoryData(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void GetPosts(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task AddNewPost(PostModel newPost, bool isPublished, IDbService dbService)
        {
            var postModel = new PostModel
            {
                Title = newPost.Title,
                CategoryId = CategoryModel.CategoryId,
                Text = newPost.Text,
                Author = newPost.Author,
                IsPublished = isPublished,
                Link = newPost.Link
            };

            var sql =
                $"insert into Post (Title, CategoryId, Text, Author, IsPublished, Link) values (\"{postModel.Title}\", {postModel.CategoryId}, \"{postModel.Text}\", \"{postModel.Author}\", {postModel.IsPublished}, \"{postModel.Link}\" );";

            await dbService.SaveData(sql, postModel);

            IPostViewModel newPostAdded = new PostViewModel()
            {
                PostModel = postModel
            };

            Posts.Add(newPostAdded);
        }

        public async Task EditCategory(IDbService dbService)
        {
            var sql =
                $"update Category set Title = \"{CategoryModel.Title}\", IsPublished = {CategoryModel.IsPublished}, Icon = \"{CategoryModel.Icon}\"  where CategoryId = {CategoryModel.CategoryId}";

            await dbService.SaveData(sql, CategoryModel);
        }

        public async Task DeleteCategory(IDbService dbService)
        {
            var sql = $"delete from Category where CategoryId = {CategoryModel.CategoryId}";

            await dbService.SaveData(sql, CategoryModel);
        }

        // method to compare to Categories based on their ID. This should always be used instead of '=='
        public override bool Equals(object obj)
        {
            var other = obj as ICategoryViewModel;
            return CategoryModel.CategoryId == other.CategoryModel.CategoryId;
        }

        public override int GetHashCode()
        {
            return CategoryModel.CategoryId;
        }
    }
}