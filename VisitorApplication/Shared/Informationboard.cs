namespace VisitorApplication.Shared
{
    public class Informationboard
    {
        public int InformationboardID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string QRCode { get; set; }
        public bool IsPublished { get; set; }
        public int LicenseID { get; set; }
    }
}
