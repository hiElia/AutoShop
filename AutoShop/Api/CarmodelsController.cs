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
    public class CarmodelsController : ControllerBase
    {
        private readonly AutoShopDbContext _context;

        public CarmodelsController(AutoShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Carmodels
        [HttpGet]
        public IEnumerable<Carmodel> Getcarmodels()
        {
            return _context.carmodels;
        }

        // GET: api/Carmodels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarmodel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carmodel = await _context.carmodels.FindAsync(id);

            if (carmodel == null)
            {
                return NotFound();
            }

            return Ok(carmodel);
        }

        // PUT: api/Carmodels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarmodel([FromRoute] int id, [FromBody] Carmodel carmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carmodel.id)
            {
                return BadRequest();
            }

            _context.Entry(carmodel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarmodelExists(id))
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

        // POST: api/Carmodels
        [HttpPost]
        public async Task<IActionResult> PostCarmodel([FromBody] Carmodel carmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.carmodels.Add(carmodel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarmodel", new { id = carmodel.id }, carmodel);
        }

        // DELETE: api/Carmodels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarmodel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carmodel = await _context.carmodels.FindAsync(id);
            if (carmodel == null)
            {
                return NotFound();
            }

            _context.carmodels.Remove(carmodel);
            await _context.SaveChangesAsync();

            return Ok(carmodel);
        }

        private bool CarmodelExists(int id)
        {
            return _context.carmodels.Any(e => e.id == id);
        }
    }
}