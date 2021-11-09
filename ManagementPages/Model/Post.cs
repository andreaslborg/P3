using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPages.Model
{
    public class Post
    {
        public string Title { get; set; }

        public string Text { get; set; }

        //image?

        public bool IsVisible { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
