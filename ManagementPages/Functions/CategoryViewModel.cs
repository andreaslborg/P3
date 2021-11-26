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

        public async Task EditPost(Post editPost, int categoryId, bool isPublished, IDbService dbService)
        {
            //nu laver jeg jo et nyt objekt hvilket vi ikke skal, for vi skal jo have fat i det selectede..
            Post postModel = new Post
            {
                Title = editPost.Title,
                Text = editPost.Text,
                Author = editPost.Author,
                IsPublished = isPublished
            };

            //postId skal også være dynamisk jo :P
            string sql = @"update Post set Title = @Title, Text = @Text, Author = @Author, IsPublished = @IsPublished where PostId = 10";

            await dbService.SaveData(sql, postModel);

            IPostViewModel newPostAdded = new PostViewModel();
            newPostAdded.PostModel = postModel;
        }

    }
}