using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorApp.Shared;
using VisitorApp.Server.Services;

namespace VisitorApp.Server.Controllers
{
    [Route("api/[controller]")]
    //den første del af navnet TestController er sådan man tilgår den, så api/Test
    public class TestController : Controller
    {
        
        readonly ITest _ITest;

        public TestController(ITest Itest)
        {
            _ITest = Itest;
        }

        //for at gette listen bliver det så til api/Test/TestList
        [HttpGet("[action]")]
        public async Task<List<Test>> TestList()
        {
            var test = await _ITest.TestList();
            return test;
        }
    }
}
