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

        //sorting af categories, er det her den skal være? 

        public string Name { get; set; }

        public List<Category> Categories { get; set; }

        public bool IsPublished { get; set; }
    }
}
