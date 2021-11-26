using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class LicenseViewModel : ILicenseViewModel
    {
        private IInformationBoardViewModel _selectedInformationBoard;

        public License LicenseModel { get; set; }

        public List<IInformationBoardViewModel> InformationBoards { get; } = new();

        public IInformationBoardViewModel SelectedInformationBoard
        {
            get => _selectedInformationBoard ?? InformationBoards.FirstOrDefault();
            set => _selectedInformationBoard = value;
        }
    }
}