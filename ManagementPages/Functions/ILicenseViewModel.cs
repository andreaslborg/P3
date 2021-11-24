using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    interface ILicenseViewModel
    {
        public License LicenseModel { get; set; }

        //List<IInformationBoardViewModel> InformationBoards = new List<IInformationBoardViewModel>();

        public void GetLicenseData(int licenseId);

        public void GetInformationBoards(int licenseId);
    }
}
