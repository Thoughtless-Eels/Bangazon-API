
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
    public class TrainingProgramController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public TrainingProgramController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }


        // Initiate the Get Request for Training Program:
        [HttpGet]
        public IActionResult Get()
        {
            var TrainingProgram = _context.TrainingProgram.ToList();
            if (TrainingProgram == null)
            {
                return NotFound();
            }
            return Ok(TrainingProgram);
        }



        // Refrencing the model?
        // GET api/album/5
        [HttpGet("{id}", Name = "GetSingleTrainingProgram")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                TrainingProgram trainingprogram = _context.TrainingProgram.Single(g => g.TrainingProgramId == id);

                if (trainingprogram == null)
                {
                    return NotFound();
                }

                return Ok(trainingprogram);
            }

            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }
        // Initiate the Post Request
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]TrainingProgram trainingprogram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TrainingProgram.Add(trainingprogram);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrainingProgramExists(trainingprogram.TrainingProgramId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleTrainingProgram", new { id = trainingprogram.TrainingProgramId }, trainingprogram);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TrainingProgram trainingprogram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainingprogram.TrainingProgramId)
            {
                return BadRequest();
            }
            _context.TrainingProgram.Update(trainingprogram);
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TrainingProgram trainingprogram = _context.TrainingProgram.Single(g => g.TrainingProgramId == id);

            if (trainingprogram == null)
            {
                return NotFound();
            }
            _context.TrainingProgram.Remove(trainingprogram);
            _context.SaveChanges();
            return Ok(trainingprogram);
        }


        // create the instance of the training program:
        private bool TrainingProgramExists(int trainingprogramId)
        {
            return _context.TrainingProgram.Any(g => g.TrainingProgramId == trainingprogramId);
        }

    }
}