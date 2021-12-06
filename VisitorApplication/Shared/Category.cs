namespace VisitorApplication.Shared
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int InformationBoardId { get; set; }
        public string Title { get; set; }
        public bool IsPublished { get; set; }
        public string Icon { get; set; }
    }
}
