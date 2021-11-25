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
            var result = new License();

            // hvis vi fetcher et felt ad gangen: 
            result.LicenseId = licenseId;
            result.RegistrationDate = ..; //kald til db

            // hvis vi fetcher et helt objekt ad gangen: 
            result = ... ; //kald til db

            LicenseModel = result;
        }

        public void GetInformationBoards(int licenseId)
        {
            // lave informationboard objekter ud fra licenseId i et loop (where licenseId = licenseId)
            // først skal vi identificere deres Id
            InformationBoards.Add(new InformationBoardViewModel(_dbService, informationBoardId));
        }
    }
}