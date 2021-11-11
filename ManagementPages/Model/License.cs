using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ManagementPages.Model
{
    public class License
    {
        public Guid LicenseNumber { get; set; }

        public List<InformationBoard> InformationBoards = new();

        public DateTime RegistrationDate { get; set; }
    }
}
