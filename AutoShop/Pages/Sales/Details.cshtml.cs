﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoShop.Core;
using AutoShop.Data;

namespace AutoShop.Pages.Sales
{
    public class DetailsModel : PageModel
    {
        private readonly AutoShop.Data.AutoShopDbContext _context;

        public DetailsModel(AutoShop.Data.AutoShopDbContext context)
        {
            _context = context;
        }

        public Sale Sale { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sale = await _context.sales.FirstOrDefaultAsync(m => m.id == id);

            if (Sale == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
