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
            InformationBoardModel = new InformationBoardModel();
        }

        public InformationBoardModel InformationBoardModel { get; set; }

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

        public async Task AddNewCategory(CategoryModel newCategory, int informationBoardId, bool isPublished, IDbService dbService)
        {
            CategoryModel categoryModel = new CategoryModel
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
    }

}
