using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoShop.Core;
using AutoShop.Data;

namespace AutoShop.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly AutoShop.Data.AutoShopDbContext _context;

        public DetailsModel(AutoShop.Data.AutoShopDbContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.employees.FirstOrDefaultAsync(m => m.id == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
