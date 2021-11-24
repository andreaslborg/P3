using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPages.Model
{
    public class Post
    {
        public int PostId { get; set; } //skal vi bruge dette til noget?

        public string Title { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public string Image { get; set; }

        public string Audio { get; set; }
        
        public bool IsPublished { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
