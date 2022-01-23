using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoShop.Core;
using AutoShop.Data;

namespace AutoShop.Pages.CarModels
{
    public class IndexModel : PageModel
    {
        private readonly AutoShop.Data.AutoShopDbContext _context;

        public IndexModel(AutoShop.Data.AutoShopDbContext context)
        {
            _context = context;
        }

        public IList<Carmodel> Carmodel { get;set; }

        public async Task OnGetAsync()
        {
            Carmodel = await _context.carmodels.ToListAsync();
        }
    }
}
