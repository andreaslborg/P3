using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface IInformationBoardViewModel
    {
        public InformationBoardModel InformationBoardModel { get; set; }

        Dictionary<int, ICategoryViewModel> Categories { get; set; }

        public ICategoryViewModel SelectedCategory { get; set; }

        List<int> CategoryOrder { get; set; }

        public void GetInformationBoardData(int informationBoardId);

        public void GetCategories(int informationBoardId);

        public Task AddNewCategory(CategoryModel newCategory, bool isPublished,
            IDbService dbService);

        Task EditInformationBoard(IDbService dbService);

        public void CheckCategoryOrder();

        Task EditCategoryOrder(IDbService dbService);
    }
}