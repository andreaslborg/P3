using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPages.Model
{
    public class InformationBoard
    {
        //QR code?

        //Url?

        public string Name { get; set; }

        public List<Category> Categories { get; set; }

        public bool IsPublished { get; set; }
    }
}
