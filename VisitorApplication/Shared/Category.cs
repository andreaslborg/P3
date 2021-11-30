using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorApplication.Shared
{
    public class Category
    {
        public int CategoryId { get; set; }

        public int InformationBoardId { get; set; }

        public string Title { get; set; }

        public bool IsPublished { get; set; }

       

        //Skal assignes i constructor - dependency injection 
        //public ISortingMachine PostSortingMachine { get; set; }
    }
}
