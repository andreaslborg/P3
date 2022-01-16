using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementPages.Model.InformationBoard;
using ManagementPages.Services;

namespace ManagementPages.Model.License
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
                try
                {
                    if (!informationBoardDataModel.ContentIsValid)
                        throw new Exception("Problem with information board");

                    IInformationBoardModel informationBoardModel = new InformationBoardModel
                    {
                        InformationBoardDataModel = informationBoardDataModel
                    };

                    informationBoardModel.Categories = await informationBoardModel.LoadCategories(dbService);

                    result.Add(informationBoardModel);

                    if (informationBoardDataModel.CategoryOrder != null)
                        informationBoardModel.CategoryOrder =
                            ConversionService.ConvertCommaSeparatedStringToListOfInt(informationBoardDataModel.CategoryOrder);

                    informationBoardModel.CheckCategoryOrder();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return result;
        }

        public async Task<LicenseDataModel> LoadLicenseDataModel(int licenseId, IDbService dbService)
        {
            var sql = $"select * from License where LicenseId = {licenseId};";
            var licenseList = await dbService.LoadData<LicenseDataModel, dynamic>(sql, new { });

            if(licenseList.Count <= 0)
            {
                throw new Exception("Not valid licenseID");
            }
            else
            {
                return licenseList.First();
            }
        }

        private async Task<List<InformationBoardDataModel>> LoadInformationBoardDataModels(IDbService dbService)
        {
            var sql = $"select * from InformationBoard where LicenseId = {LicenseDataModel.LicenseId};";
            return await dbService.LoadData<InformationBoardDataModel, dynamic>(sql, new { });
        }
    }
}