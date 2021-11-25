using System.Collections.Generic;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface IInformationBoardViewModel
    {
        public InformationBoard InformationBoardModel { get; set; }

        List<ICategoryViewModel> Categories { get; set; }

        public void GetInformationBoardData(int informationBoardId);

        public void GetCategories(int informationBoardId);

        public ICategoryViewModel SelectedCategory { get; set; }
    }
}