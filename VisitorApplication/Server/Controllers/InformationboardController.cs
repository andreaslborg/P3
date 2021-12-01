using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorApplication.Shared;

namespace VisitorApplication.Server.Controllers
{
    [Route("api/[controller]")]
    //den første del af navnet TestController er sådan man tilgår den, så api/Test
    public class InformationboardController : Controller
    {
        readonly IInformationboard _IInformationboard;

        public InformationboardController(IInformationboard IInformationboard)
        {
            _IInformationboard = IInformationboard;
        }

        //for at gette listen bliver det så til api/Test/TestList
        [HttpGet("[action]")]
        public async Task<List<Informationboard>> InformationboardList()
        {
            var informationboards = await _IInformationboard.InformationboardList();
            return informationboards;
        }
    }
}
