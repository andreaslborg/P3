using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorApplication.Shared
{
    public class Post
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public bool IsPublished { get; set; }
        public string Link { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
        public int CategoryID { get; set; }

        public bool ContentIsValid => CheckIfContentIsValid();

        private bool CheckIfContentIsValid()
        {
            return !string.IsNullOrEmpty(Title) && Title.Length <= 30
                                                && PostID > 0
                                                && CategoryID > 0
                                                && !string.IsNullOrEmpty(Text) && Text.Length <= 429496729
                                                && !string.IsNullOrEmpty(Author) && Author.Length <= 100;
        }
    }
}
