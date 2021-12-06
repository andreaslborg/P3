using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string CategoryOrder { get; set; }


        public void CategoryOrderGenerator(Informationboard informationboard)
        {
            int i = 0;
            List<int> categoryOrder;
            string line = informationboard.CategoryOrder;
            string[] lineArray;

            lineArray = line.Split(",");

            foreach (var item in categoryOrder)
            {
                item = Convert.ToInt32(lineArray[i]);
                i++;
            }
                
            

        }
    }
}
