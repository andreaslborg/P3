using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VisitorApplication.Shared;

namespace VisitorApplication.Server.Controllers
{
    [Route("api/[controller]")]
    //den første del af navnet CategoryController er sådan man tilgår den, så api/Category
    public class CategoryController : Controller
    {
        readonly ICategory _ICategory;

        public CategoryController(ICategory Icategory)
        {
            _ICategory = Icategory;
        }

        [HttpGet("[action]")]
        //for at gette listen bliver det så til api/Category/CategoryList
        public async Task<List<Category>> CategoryList()
        {
            var categories = await _ICategory.CategoryList();
            return categories;
        }
    }
}
