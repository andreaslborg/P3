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

        public InformationBoardViewModel(int informationBoardId)
        {
            GetInformationBoardData(informationBoardId);
            GetCategories(informationBoardId);
        }

        public InformationBoardViewModel()
        {
            InformationBoardModel = new InformationBoard();
        }

        public InformationBoard InformationBoardModel { get; set; }

        public List<ICategoryViewModel> Categories { get; set; } = new();

        public void GetInformationBoardData(int informationBoardId)
        {
            throw new NotImplementedException();
        }

        public void GetCategories(int informationBoardId)
        {
            throw new NotImplementedException();
        }

        public ICategoryViewModel SelectedCategory
        {
            get => _selectedCategory ?? Categories.FirstOrDefault();
            set => _selectedCategory = value;
        }

        public async Task AddNewCategory(Category newCategory, int informationBoardId, bool isPublished, IDbService dbService)
        {
            Category categoryModel = new Category
            {
                Title = newCategory.Title,
                InformationBoardId = informationBoardId,
                IsPublished = isPublished
            };

            string sql = @"insert into Category (Title, InformationBoardId, IsPublished)
                values (@Title, @InformationBoardId, @IsPublished);";

            await dbService.SaveData(sql, categoryModel);

            ICategoryViewModel newCategoryAdded = new CategoryViewModel();
            newCategoryAdded.CategoryModel = categoryModel;

            Categories.Add(newCategoryAdded);
        }

        public async Task EditInformationBoard(int informationBoardId, IDbService dbService)
        {
            string sql = $"update InformationBoard set Title = \"{InformationBoardModel.Title}\", IsPublished = {InformationBoardModel.IsPublished} where InformationBoardId = {InformationBoardModel.InformationBoardId}";

            await dbService.SaveData(sql, InformationBoardModel);
        }
    }

}
