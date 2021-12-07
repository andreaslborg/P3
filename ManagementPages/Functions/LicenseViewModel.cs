using System.Collections.Generic;
using System.Linq;
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
    }
}