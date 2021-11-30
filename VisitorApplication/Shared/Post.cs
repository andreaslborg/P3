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
        public DateTime ExpirationDate { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
        public int CategoryID { get; set; }
    }
}
