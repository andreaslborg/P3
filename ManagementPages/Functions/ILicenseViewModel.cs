using System.Collections.Generic;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface ILicenseViewModel
    {
        public License LicenseModel { get; set; }

        public List<IInformationBoardViewModel> InformationBoards { get; }

        public IInformationBoardViewModel SelectedInformationBoard { get; set; }

        public void GetLicenseData(int licenseId);

        public void GetInformationBoards(int licenseId);
    }
}