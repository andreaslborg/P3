using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementPages.Functions;

namespace ManagementPages.Model
{
    public class LicenseModel : ILicenseModel
    {
        private IInformationBoardModel _selectedInformationBoard;

        public LicenseDataModel LicenseDataModel { get; set; }

        public List<IInformationBoardModel> InformationBoards { get; set; } = new();

        public IInformationBoardModel SelectedInformationBoard
        {
            get => _selectedInformationBoard ?? InformationBoards.FirstOrDefault();
            set => _selectedInformationBoard = value;
        }

        public async Task<List<IInformationBoardModel>> LoadInformationBoards(IDbService dbService)
        {
            var result = new List<IInformationBoardModel>();

            var informationBoardDataModels = await LoadInformationBoardDataModels(dbService);

            foreach (var informationBoardDataModel in informationBoardDataModels)
            {
                var informationBoardModel = new InformationBoardModel
                {
                    InformationBoardDataModel = informationBoardDataModel,
                };
                informationBoardModel.Categories = await informationBoardModel.LoadCategories(dbService);

                result.Add(informationBoardModel);

                if (informationBoardDataModel.CategoryOrder != null)
                {
                    informationBoardModel.CategoryOrder =
                        informationBoardModel.ConvertToListOfInt(informationBoardDataModel.CategoryOrder);
                }

                informationBoardModel.CheckCategoryOrder();
            }

            return result;
        }

        public async Task<LicenseDataModel> LoadLicenseDataModel(int licenseId, IDbService dbService)
        {
            var sql = $"select * from License where LicenseId = {licenseId};";
            var licenseList = await dbService.LoadData<LicenseDataModel, dynamic>(sql, new { });

            return licenseList.First();
        }

        private async Task<List<InformationBoardDataModel>> LoadInformationBoardDataModels(IDbService dbService)
        {
            var sql = $"select * from InformationBoard where LicenseId = {LicenseDataModel.LicenseId};";
            return await dbService.LoadData<InformationBoardDataModel, dynamic>(sql, new { });
        }
    }
}
