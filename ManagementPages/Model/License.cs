using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPages.Model
{
    public class License
    {
        public int LicenseNumber { get; set; }

        public List<InformationBoard> InformationBoards = new();

        public DateTime RegistrationDate { get; set; }
    }
}
