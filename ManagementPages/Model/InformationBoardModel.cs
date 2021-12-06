using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPages.Model
{
    public class InformationBoardModel
    {
        public int InformationBoardId { get; set; }

        public int LicenseId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string QRCode { get; set; }

        public bool IsPublished { get; set; }

        public string CategoryOrder { get; set; }

        // hvis det skal virke, skal ovenstående category order smides på viewmodel'en, og så skal der laves en categoryorderstring
        // på modellen, som så skal parses/konverteres, når den skal hentes fra/lægges i databasen

        //Skal assignes i constructor - dependency injection 
        //Skal være manuel sortering
        //public ISortingMachine CategorySortingMachine { get; set; }
    }
}