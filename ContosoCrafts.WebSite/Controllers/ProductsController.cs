using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models;

namespace ContosoCrafts.WebSite.Controllers
{
    //ROUTE WE WANT (/Products is taken from ProductsController.cs class name to get endpoint)
    [Route("[controller]")]
    [ApiController]

    //Product Controller Inherits ControllerBase
    public class ProductsController : ControllerBase
    {
        //JsonFileProductService can be used by adding it as a parameter (no need to use "new")
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }


        //This says when people makes an Http Get Request call Get()
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            //Returns all Products
            return ProductService.GetProducts();
        }
    }
}
