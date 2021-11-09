using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPages.Model
{
    public class Category
    {
        public string Title { get; set; }

        public List<Post> Posts { get; set; }

        public bool IsPublished { get; set; }

        //icon?
        
    }
}
