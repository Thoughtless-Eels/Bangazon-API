using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thoughtless_eels.Data;
using thoughtless_eels.Models;

namespace thoughtless_eels.Controllers
{
    
    [Route("api/[controller]")]
    public class TrainingProgramController : Controller
    {    
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public TrainingProgramController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var trainingProgram = _context.TrainingProgram.ToList();
            if (trainingProgram == null)
            {
                return NotFound();
            }
            return Ok(trainingProgram);
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
                TrainingProgram trainingProgram = _context.TrainingProgram.Single(c => c.TrainingProgramId == id);

                if (trainingProgram == null)
                {
                    return NotFound();
                }

                return Ok(trainingProgram);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]TrainingProgram trainingProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TrainingProgram.Add(trainingProgram);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrainingProgramExists(trainingProgram.TrainingProgramId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleOrder", new { id = trainingProgram.TrainingProgramId }, trainingProgram);
        }

                [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TrainingProgram trainingProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainingProgram.TrainingProgramId)
            {
                return BadRequest();
            }
            _context.TrainingProgram.Update(trainingProgram);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingProgramExists(id))
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
            TrainingProgram trainingProgram = _context.TrainingProgram.Single(c => c.TrainingProgramId == id);

            if (trainingProgram == null)
            {
                return NotFound();
            }
            _context.TrainingProgram.Remove(trainingProgram);
            _context.SaveChanges();
            return Ok(trainingProgram);
        }

        private bool TrainingProgramExists(int trainingProgramId)
        {
            return _context.TrainingProgram.Any(c => c.TrainingProgramId == trainingProgramId);
        }
    }
}