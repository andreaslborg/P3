using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginPage4.Authorization
{
    public class EmailRequirement : IAuthorizationRequirement
    {
        public string EmailSuffix { get; }

        public EmailRequirement(string emailSuffix)
        {
            this.EmailSuffix = emailSuffix;
        }
    }
}
