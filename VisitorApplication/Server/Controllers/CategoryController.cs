using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorApplication.Shared;

namespace VisitorApplication.Server.Controllers
{
    [Route("api/[controller]")]
    // The first part of the controller name (category) is how the api/controller will be accesed,
    // meaning ..api/category
    public class CategoryController : Controller
    {
        readonly ICategory _ICategory;

        public CategoryController(ICategory Icategory)
        {
            _ICategory = Icategory;
        }

        // The method CategoryList will be invoked at api/catgory/categorylist
        [HttpGet("[action]")]
        public async Task<List<Category>> CategoryList()
        {
            var categories = await _ICategory.CategoryList();
            return categories;
        }
    }
}
