namespace ManagementPages.Model.InformationBoard
{
    public class InformationBoardDataModel
    {
        public int InformationBoardId { get; set; }

        public int LicenseId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string QRCode { get; set; }

        public bool IsPublished { get; set; }

        public string CategoryOrder { get; set; }
    }
}