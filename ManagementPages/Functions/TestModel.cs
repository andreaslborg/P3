using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementPages.Functions
{
    public class TestModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Too long")]
        [MinLength(2, ErrorMessage = "Too short")]
        public string Name { get; set; }
    }
}
