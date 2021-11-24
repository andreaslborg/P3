using System;
using System.Collections.Generic;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class LicenseViewModel : ILicenseViewModel
    {
        private DbService _dbService;

        public LicenseViewModel(DbService dbService, int licenseId)
        {
            _dbService = dbService;
            InformationBoards = new List<IInformationBoardViewModel>();
            GetLicenseData(licenseId);
            GetInformationBoards(licenseId);
        }

        public License LicenseModel { get; set; }

        public List<IInformationBoardViewModel> InformationBoards { get; }

        public void GetLicenseData(int licenseId)
        {
            throw new NotImplementedException();
        }

        public void GetInformationBoards(int licenseId)
        {
            throw new NotImplementedException();
        }
    }
}