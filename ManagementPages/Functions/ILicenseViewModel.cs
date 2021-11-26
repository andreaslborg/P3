using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface ILicenseViewModel
    {
        public License LicenseModel { get; set; }

        public List<IInformationBoardViewModel> InformationBoards { get; }

        public IInformationBoardViewModel SelectedInformationBoard { get; set; }
    }
}