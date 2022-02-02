using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoShop.Core;
using AutoShop.Data;

namespace AutoShop.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly AutoShopDbContext _context;

        public SalesController(AutoShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public IEnumerable<Sale> Getsales()
        {
            return _context.sales;
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sale = await _context.sales.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }
        // GET: api/Sales/Employee/2
        [HttpGet("employee/{id}")]
        public async Task<IActionResult> GetSalesByEmployeeId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var salesByEmployee = await _context.sales.Where(s => s.employee_id == id).ToListAsync();
            var carmodels = await _context.carmodels.ToListAsync();
            var totalSales = 0;
            salesByEmployee.ForEach(sales =>
            {
                var soldCar = carmodels.FirstOrDefault(c => c.id == sales.carmodel_id);
                var price = soldCar.price; 
                totalSales += price;
            });
            var employee = await _context.employees.FindAsync(id);

            return Ok(new { Name = employee.name, Sales =  totalSales });
        }

        // PUT: api/Sales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale([FromRoute] int id, [FromBody] Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sale.id)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sales
        [HttpPost]
        public async Task<IActionResult> PostSale([FromBody] Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.sales.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = sale.id }, sale);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sale = await _context.sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.sales.Remove(sale);
            await _context.SaveChangesAsync();

            return Ok(sale);
        }

        private bool SaleExists(int id)
        {
            return _context.sales.Any(e => e.id == id);
        }
    }
}