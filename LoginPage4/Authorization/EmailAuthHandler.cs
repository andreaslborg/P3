using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginPage4.Authorization
{
    public class EmailAuthHandler : AuthorizationHandler<EmailRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailRequirement requirement)
        {
            if (context.User.Identity.Name.EndsWith(requirement.EmailSuffix))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
