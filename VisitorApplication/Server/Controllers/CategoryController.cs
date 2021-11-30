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
    public class CategoryController : Controller
    {
        readonly ICategory _ICategory;

        public CategoryController(ICategory Icategory)
        {
            _ICategory = Icategory;
        }

        //for at gette listen bliver det så til api/Test/TestList
        [HttpGet("[action]")]
        public async Task<List<Category>> CategoryList()
        {
            var categories = await _ICategory.CategoryList();
            return categories;
        }
    }
}
