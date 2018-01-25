using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thoughtless_eels.Data;
using thoughtless_eels.Models;


namespace thoughtless_eels.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private bool CustomerExists(int customerId)
        {
            return _context.Customer.Any(g => g.CustomerId == customerId);
        }
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public CustomersController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customer.Add(customer);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.CustomerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleCustomer", new { id = customer.CustomerId }, customer);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _context.Customer.ToList();
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetSingleCustomer")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Customer customer = _context.Customer.Single(g => g.CustomerId == id);

                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerId)
            {
                return BadRequest();
            }
            _context.Customer.Update(customer);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Customer customer = _context.Customer.Single(g => g.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }
            _context.Customer.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);
        }


    }
}