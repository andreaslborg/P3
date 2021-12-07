using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementPages.Model;
using Microsoft.VisualBasic;


namespace ManagementPages.Functions
{
    public class InformationBoardViewModel : IInformationBoardViewModel
    {
        private ICategoryViewModel _selectedCategory;

        public InformationBoardModel InformationBoardModel { get; set; } = new();

        public Dictionary<int, ICategoryViewModel> Categories { get; set; } = new();

        public async Task<Dictionary<int, ICategoryViewModel>> LoadCategories(IDbService dbService)
        {
            var result = new Dictionary<int, ICategoryViewModel>();

            var categoryModels = await GetCategoryModels(dbService);

            foreach (var categoryModel in categoryModels)
            {
                var category = new CategoryViewModel
                {
                    CategoryModel = categoryModel,
                };
                category.Posts = await category.LoadPosts(dbService);

                result.Add(category.GetHashCode(), category);
            }

            return result;
        }

        private async Task<List<CategoryModel>> GetCategoryModels(IDbService dbService)
        {
            var sql = $"select * from Category where InformationBoardId = {InformationBoardModel.InformationBoardId};";
            return await dbService.LoadData<CategoryModel, dynamic>(sql, new { });
        }

        public ICategoryViewModel SelectedCategory
        {
            get => _selectedCategory ?? Categories.FirstOrDefault().Value;
            set => _selectedCategory = value;
        }

        public List<int> CategoryOrder { get; set; } = new();

        public async Task AddNewCategory(CategoryModel newCategory, bool isPublished, IDbService dbService)
        {
            CategoryModel categoryModel = new()
            {
                Title = newCategory.Title,
                InformationBoardId = InformationBoardModel.InformationBoardId,
                IsPublished = isPublished,
                Icon = newCategory.Icon
            };

            string sql = $"insert into Category (Title, InformationBoardId, IsPublished, Icon) values(\"{categoryModel.Title}\", {categoryModel.InformationBoardId}, {categoryModel.IsPublished}, \"{categoryModel.Icon}\"); ";

            await dbService.SaveData(sql, categoryModel);
        }

        public async Task EditInformationBoard(IDbService dbService)
        {
            string sql = $"update InformationBoard set Title = \"{InformationBoardModel.Title}\", IsPublished = {InformationBoardModel.IsPublished} where InformationBoardId = {InformationBoardModel.InformationBoardId}";

            await dbService.SaveData(sql, InformationBoardModel);
        }

        // method to compare to information boards based on their ID. This should always be used instead of '=='
        public override bool Equals(object obj)
        {
            var other = obj as IInformationBoardViewModel;
            return InformationBoardModel.InformationBoardId == other.InformationBoardModel.InformationBoardId;
        }

        public override int GetHashCode()
        {
            return InformationBoardModel.InformationBoardId;
        }

        public string ConvertToCommaSeparatedString(List<int> list)
        {
            string result = String.Empty;

            foreach(var number in list)
            {
                result += $"{number},";
            }

            return result;
        }

        public async Task EditCategoryOrder(IDbService dbService)
        {
            InformationBoardModel.CategoryOrder = ConvertToCommaSeparatedString(CategoryOrder);

            string sql = $"update InformationBoard set CategoryOrder = \"{InformationBoardModel.CategoryOrder}\"  where InformationBoardId = {InformationBoardModel.InformationBoardId}";

            await dbService.SaveData(sql, InformationBoardModel);
        }

        public List<int> ConvertToListOfInt(string input)
        {
            List<int> result = new();
            var list = input.Split(',');

            foreach (var numberString in list)
            {
                try
                {
                    var number = Int32.Parse(numberString);
                    result.Add(number);
                }
                catch (FormatException)
                {
                    // Handle
                }
            }

            return result;
        }

        public void CheckCategoryOrder()
        {
            // check if all categories are in the CategoryOrder (meaning that they will be displayed), and
            // add them to the end, if they are missing
            List<int> keysToAdd = new();
            List<int> keysToRemove = new();

            foreach (var category in Categories)
            {
                if (!CategoryOrder.Contains(category.Key))
                {
                    keysToAdd.Add(category.Key);
                }
            }

            // check if there are any invalid ids in the CategoryOrder, and if so - delete them
            foreach (var key in CategoryOrder)
            {
                if (!Categories.ContainsKey(key))
                {
                    keysToRemove.Add(key);
                }
            }

            // keys cannot be deleted/added inside foreach loop as it messes up the order
            foreach (var key in keysToAdd)
            {
                CategoryOrder.Add(key);
            }

            foreach (var key in keysToRemove)
            {
                CategoryOrder.Remove(key);
            }
        }
    }
}
