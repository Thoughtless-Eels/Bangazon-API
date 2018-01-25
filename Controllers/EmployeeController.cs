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
    public class EmployeeController : Controller
    {
        private bool EmployeeExists(int employeeId)
        {
            return _context.Employee.Any(g => g.EmployeeId == employeeId);
        }
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public EmployeeController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employee.Add(employee);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.EmployeeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleEmployee", new { id = employee.EmployeeId }, employee);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = _context.Employee.ToList();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetSingleEmployee")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Employee employee = _context.Employee.Single(g => g.EmployeeId == id);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }
            _context.Employee.Update(employee);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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
            Employee employee = _context.Employee.Single(g => g.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }
            _context.Employee.Remove(employee);
            _context.SaveChanges();
            return Ok(employee);
        }


    }
}