using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementPages.Function;

namespace ManagementPages.Model
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
            {
                var categoryModel = new CategoryModel
                {
                    CategoryDataModel = categoryDataModel
                };
                categoryModel.Posts = await categoryModel.LoadPosts(dbService);

                categoryModel.CategoryDeleted += DeleteCategory;

                result.Add(categoryModel.GetHashCode(), categoryModel);
            }

            return result;
        }

        public void DeleteCategory(CategoryModel categoryModel)
        {
            Categories.Remove(categoryModel.GetHashCode());
            CategoryOrder.Remove(categoryModel.GetHashCode());
        }

        public ICategoryModel SelectedCategory
        {
            get => _selectedCategory ?? Categories.FirstOrDefault().Value;
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

            var categoryModel = new CategoryModel()
            {
                CategoryDataModel = categoryDataModel,
            };
            categoryModel.CategoryDeleted += DeleteCategory;

            Categories.Add(categoryModel.GetHashCode(), categoryModel);
            CategoryOrder.Add(categoryModel.GetHashCode());
        }

        public async Task EditInformationBoard(IDbService dbService)
        {
            var sql =
                $"update InformationBoard set Title = \"{InformationBoardDataModel.Title}\", IsPublished = {InformationBoardDataModel.IsPublished} where InformationBoardId = {InformationBoardDataModel.InformationBoardId}";

            await dbService.SaveData(sql, InformationBoardDataModel);
        }

        public async Task EditCategoryOrder(IDbService dbService)
        {
            InformationBoardDataModel.CategoryOrder = ConvertToCommaSeparatedString(CategoryOrder);

            var sql =
                $"update InformationBoard set CategoryOrder = \"{InformationBoardDataModel.CategoryOrder}\"  where InformationBoardId = {InformationBoardDataModel.InformationBoardId}";

            await dbService.SaveData(sql, InformationBoardDataModel);
        }

        public void CheckCategoryOrder()
        {
            // check if all categories are in the CategoryOrder (meaning that they will be displayed), and
            // add them to the end, if they are missing
            List<int> keysToAdd = new();
            List<int> keysToRemove = new();

            foreach (var category in Categories)
                if (!CategoryOrder.Contains(category.Key))
                    keysToAdd.Add(category.Key);

            // check if there are any invalid ids in the CategoryOrder, and if so - delete them
            foreach (var key in CategoryOrder)
                if (!Categories.ContainsKey(key))
                    keysToRemove.Add(key);

            // keys cannot be deleted/added inside foreach loop as it messes up the order
            foreach (var key in keysToAdd) CategoryOrder.Add(key);

            foreach (var key in keysToRemove) CategoryOrder.Remove(key);
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

        private string ConvertToCommaSeparatedString(List<int> list)
        {
            var result = string.Empty;

            foreach (var number in list) result += $"{number},";

            return result;
        }

        public List<int> ConvertToListOfInt(string input)
        {
            List<int> result = new();
            var list = input.Split(',');

            foreach (var numberString in list)
                try
                {
                    var number = int.Parse(numberString);
                    result.Add(number);
                }
                catch (FormatException)
                {
                    // Handle
                }

            return result;
        }
    }
}