using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class LicenseViewModel : ILicenseViewModel
    {
        private IInformationBoardViewModel _selectedInformationBoard;

        public LicenseModel LicenseModel { get; set; }

        public List<IInformationBoardViewModel> InformationBoards { get; set; } = new();

        public IInformationBoardViewModel SelectedInformationBoard
        {
            get => _selectedInformationBoard ?? InformationBoards.FirstOrDefault();
            set => _selectedInformationBoard = value;
        }

        public async Task<List<IInformationBoardViewModel>> LoadInformationBoards(IDbService dbService)
        {
            var result = new List<IInformationBoardViewModel>();

            var informationBoardModels = await LoadInformationBoardModels(dbService);

            foreach (var informationBoardModel in informationBoardModels)
            {
                var informationBoard = new InformationBoardViewModel
                {
                    InformationBoardModel = informationBoardModel,
                };
                informationBoard.Categories = await informationBoard.LoadCategories(dbService);

                result.Add(informationBoard);

                if (informationBoardModel.CategoryOrder != null)
                {
                    informationBoard.CategoryOrder =
                        informationBoard.ConvertToListOfInt(informationBoardModel.CategoryOrder);
                }

                informationBoard.CheckCategoryOrder();
            }

            return result;
        }

        public async Task<LicenseModel> LoadLicenseData(int licenseId, IDbService dbService)
        {
            var sql = $"select * from License where LicenseId = {licenseId};";
            var licenseList = await dbService.LoadData<LicenseModel, dynamic>(sql, new { });

            return licenseList.First();
        }

        private async Task<List<InformationBoardModel>> LoadInformationBoardModels(IDbService dbService)
        {
            var sql = $"select * from InformationBoard where LicenseId = {LicenseModel.LicenseId};";
            return await dbService.LoadData<InformationBoardModel, dynamic>(sql, new { });
        }
    }
}
