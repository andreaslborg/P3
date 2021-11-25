using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace ManagementPages.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        public string Title { get; set; }

        public List<Post> Posts = new();

        public bool IsPublished { get; set; }

        public string Icon { get; set; }

        //https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color?view=net-5.0 
        public Color ColorOfCategory { get; set; }

        //Skal assignes i constructor - dependency injection 
        //public ISortingMachine PostSortingMachine { get; set; }

    }
}
