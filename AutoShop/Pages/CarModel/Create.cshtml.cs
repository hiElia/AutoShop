using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoShop.Core;
using AutoShop.Data;

namespace AutoShop.Pages.CarModel
{
    public class CreateModel : PageModel
    {
        private readonly AutoShop.Data.AutoShopDbContext _context;

        public CreateModel(AutoShop.Data.AutoShopDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Carmodel Carmodel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.carmodels.Add(Carmodel);
            Carmodel.id = _context.carmodels.Max(c => c.id) + 1;
           
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}