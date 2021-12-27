using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService ProductService;

        //Create a set of Products that are private to this class
        public IEnumerable<Product> Products { get; private set; }


        //added JSON file Product service
        public IndexModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }


        //When someone "GETS" this page. What should we do?
        public void OnGet()
        {
            //define Products to the Products returned by the ProductService (JsonFileProductService)
            Products = ProductService.GetProducts();
        }
    }
}
