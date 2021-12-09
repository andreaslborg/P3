using System.ComponentModel.DataAnnotations;

namespace ManagementPages.Model
{
    public class InformationBoardDataModel
    {
        public int InformationBoardId { get; set; }

        public int LicenseId { get; set; }

        [Required(ErrorMessage = "Titel-feltet skal udfyldes")]
        [StringLength(30, ErrorMessage = "Titlen er for lang")]
        public string Title { get; set; }

        public string Url { get; set; }

        public string QRCode { get; set; }

        public bool IsPublished { get; set; }

        public string CategoryOrder { get; set; }
    }
}