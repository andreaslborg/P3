using System;
using System.Collections.Generic;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class LicenseViewModel : ILicenseViewModel
    {
        private DbService _dbService;

        public List<IInformationBoardViewModel> InformationBoards = new();

        public LicenseViewModel(DbService dbService, int licenseId)
        {
            _dbService = dbService;
            GetLicenseData(licenseId);
            GetInformationBoards(licenseId);
        }

        public License LicenseModel { get; set; }

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