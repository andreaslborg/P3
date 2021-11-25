using ManagementPages.Model;

namespace ManagementPages.Functions
{
    internal interface ILicenseViewModel
    {
        public License LicenseModel { get; set; }

        //List<IInformationBoardViewModel> InformationBoards = new List<IInformationBoardViewModel>();

        public void GetLicenseData(int licenseId);

        public void GetInformationBoards(int licenseId);
    }
}