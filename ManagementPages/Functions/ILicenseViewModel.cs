using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public interface ILicenseViewModel
    {
        LicenseModel LicenseModel { get; set; }

        List<IInformationBoardViewModel> InformationBoards { get; set; }

        IInformationBoardViewModel SelectedInformationBoard { get; set; }

        Task<LicenseModel> LoadLicenseData(int licenseId, IDbService dbService);

        Task<List<IInformationBoardViewModel>> LoadInformationBoards(IDbService dbService);
    }
}