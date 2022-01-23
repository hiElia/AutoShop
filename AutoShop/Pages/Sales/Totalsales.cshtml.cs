using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoShop.Core;
using AutoShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AutoShop.Pages.Sales
{
    public class TotalsalesModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly ICarShopData carShopData;

        public string Message { get; set; }
        public IEnumerable<Sale> Sales { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public TotalsalesModel(IConfiguration config, ICarShopData carShopData)
        {
            this.config = config;
            this.carShopData = carShopData;

        }
       
        public void OnGet(string serchTerm)
        {
            Sales = carShopData.GetTotalSales(SearchTerm);
            
        }
       
    }
}
