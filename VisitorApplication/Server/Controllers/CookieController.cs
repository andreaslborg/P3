using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorApplication.Server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CookieController : ControllerBase
    {
        //not in use
        [HttpGet("essential")]
        public async Task<ActionResult> EssentialCookie()
        {
            CookieOptions options = new CookieOptions
            {
                IsEssential = true
            };
            Response.Cookies.Append("essentialCookie", $"{Guid.NewGuid()}", options);
            return Redirect("/");
        }

        //not in use
        [HttpGet("nonessential")]
        public async Task<ActionResult> NonEssentialCookie()
        {
            //IsEssential is false by default

            Response.Cookies.Append("essentialCookie", $"{Guid.NewGuid()}");
            return Redirect("/");
        }

        [HttpGet("consent")]
        public async Task<ActionResult> SetConsent()
        {
            ITrackingConsentFeature consent = HttpContext.Features.Get<ITrackingConsentFeature>();
            if (!consent.CanTrack)
            {
                consent.GrantConsent();
            }
            return Redirect("/");
        }
    }
}
