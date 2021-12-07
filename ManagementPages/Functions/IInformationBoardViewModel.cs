using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface IInformationBoardViewModel
    {
        InformationBoardModel InformationBoardModel { get; set; }

        Dictionary<int, ICategoryViewModel> Categories { get; set; }

        ICategoryViewModel SelectedCategory { get; set; }

        List<int> CategoryOrder { get; set; }

        Task<Dictionary<int, ICategoryViewModel>> LoadCategories(IDbService dbService);

        Task AddNewCategory(CategoryModel newCategory, bool isPublished, IDbService dbService);

        Task EditInformationBoard(IDbService dbService);

        Task EditCategoryOrder(IDbService dbService);

        void CheckCategoryOrder();
    }
}