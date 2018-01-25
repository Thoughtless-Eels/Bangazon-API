
// Training Program Controller Page:
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

    // do I need to change the router name to something more specific?
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public DepartmentController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }


        // Initiate the Get Request for Training Program:
        [HttpGet]
        public IActionResult Get()
        {
            var Department = _context.Department.ToList();
            if (Department == null)
            {
                return NotFound();
            }
            return Ok(Department);
        }



        // Refrencing the model?
        // GET api/album/5
        [HttpGet("{id}", Name = "GetSingleDepartment")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Department department = _context.Department.Single(g => g.DepartmentId == id);

                if (department == null)
                {
                    return NotFound();
                }

                return Ok(department);
            }

            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }
        // Initiate the Post Request
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Department.Add(department);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DepartmentExists(department.DepartmentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleDepartment", new { id = department.DepartmentId }, department);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.DepartmentId)
            {
                return BadRequest();
            }
            _context.Department.Update(department);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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
            Department department = _context.Department.Single(g => g.DepartmentId == id);

            if (department == null)
            {
                return NotFound();
            }
            _context.Department.Remove(department);
            _context.SaveChanges();
            return Ok(department);
        }


        // create the instance of the training program:
        private bool DepartmentExists(int departmentId)
        {
            return _context.Department.Any(g => g.DepartmentId == departmentId);
        }

    }
}