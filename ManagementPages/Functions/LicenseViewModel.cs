using System;
using System.Collections.Generic;
using System.Linq;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class LicenseViewModel : ILicenseViewModel
    {
        private DbService _dbService;
        private IInformationBoardViewModel _selectedInformationBoard;

        public LicenseViewModel(DbService dbService, int licenseId)
        {
            _dbService = dbService;
            GetLicenseData(licenseId);
            GetInformationBoards(licenseId);
        }

        public License LicenseModel { get; set; }

        public List<IInformationBoardViewModel> InformationBoards { get; } = new();

        public IInformationBoardViewModel SelectedInformationBoard
        {
            get => _selectedInformationBoard ?? InformationBoards.FirstOrDefault();
            set => _selectedInformationBoard = value;
        }

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