using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPages.Model
{
    public class InformationBoard
    {
        public int InformationBoardId { get; set; }

        public int LicenseId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string QRCode { get; set; }

        public bool IsPublished { get; set; }

        //Skal assignes i constructor - dependency injection 
        //Skal være manuel sortering
        //public ISortingMachine CategorySortingMachine { get; set; }
    }
}