using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorApplication.Shared;

namespace VisitorApplication.Server.Controllers
{
    [Route("api/[controller]")]
    public class InformationboardController : Controller
    {
        readonly IInformationboard _IInformationboard;

        public InformationboardController(IInformationboard IInformationboard)
        {
            _IInformationboard = IInformationboard;
        }

        [HttpGet("[action]")]
        public async Task<List<Informationboard>> InformationboardList()
        {
            var informationboards = await _IInformationboard.InformationboardList();
            return informationboards;
        }
    }
}
