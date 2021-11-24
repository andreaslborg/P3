using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface IInformationBoardViewModel
    {
        public InformationBoard InformationBoardModel { get; set; }

        //List<ICategoryViewModel> Categories = new List<ICategoryViewModel>();

        public void GetInformationBoardData(int informationBoardId);

        public void GetCategories(int informationBoardId);
    }
}