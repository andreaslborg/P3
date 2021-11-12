using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPages.Model
{
    public class DisplayTest
    {
       [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Too long")]
        [MinLength(2, ErrorMessage = "Too short")]
        public string Name { get; set; }
    }
}
