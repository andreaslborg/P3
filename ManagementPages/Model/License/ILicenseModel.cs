using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementPages.Function;
using ManagementPages.Model.InformationBoard;

namespace ManagementPages.Model.License
{
    public interface ILicenseModel
    {
        LicenseDataModel LicenseDataModel { get; set; }

        List<IInformationBoardModel> InformationBoards { get; set; }

        IInformationBoardModel SelectedInformationBoard { get; set; }

        Task<LicenseDataModel> LoadLicenseDataModel(int licenseId, IDbService dbService);

        Task<List<IInformationBoardModel>> LoadInformationBoards(IDbService dbService);
    }
}