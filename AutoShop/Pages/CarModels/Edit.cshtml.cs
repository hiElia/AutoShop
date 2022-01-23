using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoShop.Core;
using AutoShop.Data;

namespace AutoShop.Pages.CarModels
{
    public class EditModel : PageModel
    {
        private readonly AutoShop.Data.AutoShopDbContext _context;

        public EditModel(AutoShop.Data.AutoShopDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Carmodel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarmodelExists(Carmodel.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarmodelExists(int id)
        {
            return _context.carmodels.Any(e => e.id == id);
        }
    }
}
