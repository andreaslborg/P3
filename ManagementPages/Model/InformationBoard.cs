using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPages.Model
{
    public class InformationBoard
    {
        public int InformationBoardId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string QRCode { get; set; }

        public List<Category> Categories = new();

        public bool IsPublished { get; set; }

        //Skal assignes i constructor - dependency injection 
        //Skal være manuel sortering
        //public ISortingMachine CategorySortingMachine { get; set; }
    }
}
