using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementPages.Model.Post;
using ManagementPages.Services;

namespace ManagementPages.Model.Category
{
    public class CategoryModel : ICategoryModel
    {
        public List<IPostModel> Posts { get; set; } = new();

        public CategoryDataModel CategoryDataModel { get; set; }

        public async Task<List<IPostModel>> LoadPosts(IDbService dbService)
        {
            var result = new List<IPostModel>();

            var postDataModels = await LoadPostDataModels(dbService);

            foreach (var postDataModel in postDataModels)
                try
                {
                    if (!postDataModel.ContentIsValid) throw new Exception("Invalid post");

                    var postModel = new PostModel
                    {
                        PostDataModel = postDataModel
                    };

                    // if a post is deleted, the deletePost method on the category will be called, because the event is invoked
                    postModel.PostDeleted += DeletePost;

                    result.Add(postModel);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            return result;
        }

        public async Task AddNewPost(PostDataModel newPost, bool isPublished, IDbService dbService)
        {
            var postDataModel = new PostDataModel
            {
                Title = newPost.Title,
                CategoryId = CategoryDataModel.CategoryId,
                Text = newPost.Text,
                Author = newPost.Author,
                IsPublished = isPublished,
                Link = newPost.Link
            };

            // ensure that " and \ are written correctly in order to be saved in the database
            postDataModel.FixSpecialCharacters();

            var sql =
                $"insert into Post (Title, CategoryId, Text, Author, IsPublished, Link) values (\"{postDataModel.Title}\", {postDataModel.CategoryId}, \"{postDataModel.Text}\", \"{postDataModel.Author}\", {postDataModel.IsPublished}, \"{postDataModel.Link}\" );";

            await dbService.SaveData(sql, postDataModel);

            Posts = await LoadPosts(dbService);
        }

        // over-write the original category object in the database
        public async Task EditCategory(IDbService dbService)
        {
            var sql =
                $"update Category set Title = \"{CategoryDataModel.Title}\", IsPublished = {CategoryDataModel.IsPublished}, Icon = \"{CategoryDataModel.Icon}\"  where CategoryId = {CategoryDataModel.CategoryId}";

            await dbService.SaveData(sql, CategoryDataModel);
        }

        public async Task DeleteCategoryFromDatabase(IDbService dbService)
        {
            var sql = $"delete from Category where CategoryId = {CategoryDataModel.CategoryId}";

            await dbService.SaveData(sql, CategoryDataModel);

            // let subscriber know that a category has been deleted
            CategoryDeleted?.Invoke(this);
        }

        public void DeletePost(IPostModel postModel)
        {
            Posts.Remove(postModel);
        }

        public event CategoryEvent CategoryDeleted;

        private async Task<List<PostDataModel>> LoadPostDataModels(IDbService dbService)
        {
            var sql = $"select * from Post where CategoryId = {CategoryDataModel.CategoryId};";
            return await dbService.LoadData<PostDataModel, dynamic>(sql, new { });
        }

        // method to compare to Categories based on their ID. This should always be used instead of '=='
        public override bool Equals(object obj)
        {
            if (obj is ICategoryModel other) return CategoryDataModel.CategoryId == other.CategoryDataModel.CategoryId;

            return false;
        }

        public override int GetHashCode()
        {
            return CategoryDataModel.CategoryId;
        }
    }

    // declare event type for category events in the category namespace
    public delegate void CategoryEvent(CategoryModel categoryModel);
}