using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thoughtless_eels.Data;
using thoughtless_eels.Models;

namespace thoughtless_eels.Controllers
{
    
    [Route("api/[controller]")]
    public class CurrentOrderController : Controller
    {    
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public CurrentOrderController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var currentOrder = _context.CurrentOrder.ToList();
            if (currentOrder == null)
            {
                return NotFound();
            }
            return Ok(currentOrder);
        }

        [HttpGet("{id}", Name = "GetSingleOrder")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                CurrentOrder currentOrder = _context.CurrentOrder.Single(c => c.CurrentOrderId == id);

                if (currentOrder == null)
                {
                    return NotFound();
                }

                return Ok(currentOrder);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]CurrentOrder currentOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CurrentOrder.Add(currentOrder);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CurrentOrderExists(currentOrder.CurrentOrderId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleOrder", new { id = currentOrder.CurrentOrderId }, currentOrder);
        }

        [HttpPost ("{id}")]
        public IActionResult Post(int id, [FromBody]ProductOrder ProductOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			CurrentOrder currentOrder = _context.CurrentOrder.Single(co => co.CurrentOrderId == id);
			Product Product = _context.Product.Single(p => p.ProductId == ProductOrder.ProductId);
            if (currentOrder == null || Product == null)
            {
                return NotFound();
            }

            _context.ProductOrder.Add(ProductOrder);
            _context.SaveChanges();
            return CreatedAtRoute("GetSingleProduct", new { id = ProductOrder.CurrentOrderId });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CurrentOrder currentOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != currentOrder.CurrentOrderId)
            {
                return BadRequest();
            }
            _context.CurrentOrder.Update(currentOrder);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrentOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CurrentOrder currentOrder = _context.CurrentOrder.Single(c => c.CurrentOrderId == id);

            if (currentOrder == null)
            {
                return NotFound();
            }
            _context.CurrentOrder.Remove(currentOrder);
            _context.SaveChanges();
            return Ok(currentOrder);
        }

        private bool CurrentOrderExists(int currentOrderId)
        {
            return _context.CurrentOrder.Any(c => c.CurrentOrderId == currentOrderId);
        }
    }
}