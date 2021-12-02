using System.Drawing;
using System.ComponentModel.DataAnnotations;


namespace ManagementPages.Model
{
    public class Category
    {
        public int CategoryId { get; set; }

        public int InformationBoardId { get; set; }

        [Required(ErrorMessage = "Titel-feltet skal udfyldes")]
        [StringLength(30, ErrorMessage = "Titlen er for lang")]
        public string Title { get; set; }

        public bool IsPublished { get; set; }

        public string Icon { get; set; }

        //https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color?view=net-5.0 
        public Color ColorOfCategory { get; set; }

        //Skal assignes i constructor - dependency injection 
        //public ISortingMachine PostSortingMachine { get; set; }

    }
}