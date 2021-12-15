using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementPages.Model.Category;
using ManagementPages.Services;

namespace ManagementPages.Model.InformationBoard
{
    public class InformationBoardModel : IInformationBoardModel
    {
        private ICategoryModel _selectedCategory;

        public InformationBoardDataModel InformationBoardDataModel { get; set; } = new();

        public Dictionary<int, ICategoryModel> Categories { get; set; } = new();

        public async Task<Dictionary<int, ICategoryModel>> LoadCategories(IDbService dbService)
        {
            var result = new Dictionary<int, ICategoryModel>();

            var categoryDataModels = await LoadCategoryDataModels(dbService);

            foreach (var categoryDataModel in categoryDataModels)
                try
                {
                    if (!categoryDataModel.ContentIsValid) throw new Exception("Category invalid");

                    ICategoryModel categoryModel = new CategoryModel
                    {
                        CategoryDataModel = categoryDataModel
                    };
                    categoryModel.Posts = await categoryModel.LoadPosts(dbService);

                    categoryModel.CategoryDeleted += DeleteCategory;

                    result.Add(categoryModel.GetHashCode(), categoryModel);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            return result;
        }

        public ICategoryModel SelectedCategory
        {
            get => _selectedCategory ?? Categories[CategoryOrder.First()];
            set => _selectedCategory = value;
        }

        public List<int> CategoryOrder { get; set; } = new();

        public async Task AddNewCategory(CategoryDataModel newCategory, bool isPublished, IDbService dbService)
        {
            CategoryDataModel categoryDataModel = new()
            {
                Title = newCategory.Title,
                InformationBoardId = InformationBoardDataModel.InformationBoardId,
                IsPublished = isPublished,
                Icon = newCategory.Icon
            };

            var sql =
                $"insert into Category (Title, InformationBoardId, IsPublished, Icon) values(\"{categoryDataModel.Title}\", {categoryDataModel.InformationBoardId}, {categoryDataModel.IsPublished}, \"{categoryDataModel.Icon}\"); ";

            await dbService.SaveData(sql, categoryDataModel);

            ICategoryModel categoryModel = new CategoryModel
            {
                CategoryDataModel = categoryDataModel
            };

            categoryModel.CategoryDeleted += DeleteCategory;

            // reload categories from data base, so that new category receives an ID (IDs are generated in the data base)
            Categories = await LoadCategories(dbService);

            // add the new category to the category order via the CheckCategoryOrder method
            CheckCategoryOrder();
        }

        public async Task EditInformationBoard(IDbService dbService)
        {
            var sql =
                $"update InformationBoard set Title = \"{InformationBoardDataModel.Title}\", IsPublished = {InformationBoardDataModel.IsPublished} where InformationBoardId = {InformationBoardDataModel.InformationBoardId}";

            await dbService.SaveData(sql, InformationBoardDataModel);
        }

        // re-fetches the information board data from the data base, in case the information board object has been changed, and the user wants to cancel the changes
        public async Task ReloadInformationBoardDataModel(IDbService dbService)
        {
            var sql =
                $"select * from InformationBoard where InformationBoardId = {InformationBoardDataModel.InformationBoardId};";

            var informationBoardList = await dbService.LoadData<InformationBoardDataModel, dynamic>(sql, new { });

            InformationBoardDataModel = informationBoardList.First();
        }

        public async Task EditCategoryOrder(IDbService dbService)
        {
            InformationBoardDataModel.CategoryOrder = ConversionService.ConvertListToCommaSeparatedString(CategoryOrder);

            var sql =
                $"update InformationBoard set CategoryOrder = \"{InformationBoardDataModel.CategoryOrder}\"  where InformationBoardId = {InformationBoardDataModel.InformationBoardId}";

            await dbService.SaveData(sql, InformationBoardDataModel);
        }

        public void CheckCategoryOrder()
        {
            // the key is the ID of the categories, which is used as the keys in the dictionary
            List<int> keysToAdd = new();
            List<int> keysToRemove = new();

            // check if all categories are in the CategoryOrder (meaning that they will be displayed)
            foreach (var category in Categories)
                if (!CategoryOrder.Contains(category.Key))
                    keysToAdd.Add(category.Key);

            // check if there are any invalid IDs in the CategoryOrder
            foreach (var key in CategoryOrder)
                if (!Categories.ContainsKey(key))
                    keysToRemove.Add(key);

            // add/remove the identified trouble keys (keys cannot be deleted/added inside the foreach loops as it messes up the order of the items)
            foreach (var key in keysToAdd) CategoryOrder.Add(key);
            foreach (var key in keysToRemove) CategoryOrder.Remove(key);
        }

        private void DeleteCategory(CategoryModel categoryModel)
        {
            Categories.Remove(categoryModel.GetHashCode());
            CategoryOrder.Remove(categoryModel.GetHashCode());
        }

        private async Task<List<CategoryDataModel>> LoadCategoryDataModels(IDbService dbService)
        {
            var sql =
                $"select * from Category where InformationBoardId = {InformationBoardDataModel.InformationBoardId};";
            return await dbService.LoadData<CategoryDataModel, dynamic>(sql, new { });
        }

        // method to compare to information boards based on their ID. This should always be used instead of '=='
        public override bool Equals(object obj)
        {
            if (obj is IInformationBoardModel other)
                return InformationBoardDataModel.InformationBoardId ==
                       other.InformationBoardDataModel.InformationBoardId;

            return false;
        }

        public override int GetHashCode()
        {
            return InformationBoardDataModel.InformationBoardId;
        }
    }
}