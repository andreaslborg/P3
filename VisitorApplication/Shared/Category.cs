using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorApplication.Shared
{
    public class Category
    {
        public int CategoryId { get; set; }

        public int InformationBoardId { get; set; }

        public string Title { get; set; }

        public bool IsPublished { get; set; }

        public string Icon { get; set; }

        public bool ContentIsValid => CheckIfContentIsValid();

        private bool CheckIfContentIsValid()
        {
            return !string.IsNullOrEmpty(Title) && Title.Length <= 30
                                                && CategoryId > 0
                                                && InformationBoardId > 0
                                                && !string.IsNullOrEmpty(Icon);
        }
    }
}
