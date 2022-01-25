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
    public class DeleteModel : PageModel
    {
        private readonly AutoShop.Data.AutoShopDbContext _context;

        public DeleteModel(AutoShop.Data.AutoShopDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Carmodel Carmodel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Carmodel = await _context.carmodels.FirstOrDefaultAsync(m => m.id == id);

            if (Carmodel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Carmodel = await _context.carmodels.FindAsync(id);

            if (Carmodel != null)
            {
                _context.carmodels.Remove(Carmodel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
