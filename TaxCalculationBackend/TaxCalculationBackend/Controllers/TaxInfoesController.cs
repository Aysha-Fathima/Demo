using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxCalculationBackend.Models;

namespace TaxCalculationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxInfoesController : ControllerBase
    {
        private readonly UserTaxInfoContext _context = new UserTaxInfoContext();

        //public TaxInfoesController(UserTaxInfoContext context)
        //{
        //    _context = context;
        //}

        // GET: api/TaxInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxInfo>>> GetTaxInfos()
        {
          if (_context.TaxInfos == null)
          {
              return NotFound();
          }
            return await _context.TaxInfos.ToListAsync();
        }

        // GET: api/TaxInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxInfo>> GetTaxInfo(int id)
        {
          if (_context.TaxInfos == null)
          {
              return NotFound();
          }
            var taxInfo = await _context.TaxInfos.FindAsync(id);

            if (taxInfo == null)
            {
                return NotFound();
            }

            return taxInfo;
        }

        // PUT: api/TaxInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxInfo(int id, TaxInfo taxInfo)
        {
            if (id != taxInfo.TaxInfoId)
            {
                return BadRequest();
            }

            _context.Entry(taxInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxInfoExists(id))
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

        // POST: api/TaxInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaxInfo>> PostTaxInfo(TaxInfo taxInfo)
        {
          if (_context.TaxInfos == null)
          {
              return Problem("Entity set 'UserTaxInfoContext.TaxInfos'  is null.");
          }
            _context.TaxInfos.Add(taxInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxInfo", new { id = taxInfo.TaxInfoId }, taxInfo);
        }

        // DELETE: api/TaxInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxInfo(int id)
        {
            if (_context.TaxInfos == null)
            {
                return NotFound();
            }
            var taxInfo = await _context.TaxInfos.FindAsync(id);
            if (taxInfo == null)
            {
                return NotFound();
            }

            _context.TaxInfos.Remove(taxInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost("getComparison")]
        public async Task<ActionResult<TaxComparisonResponse>> GetEstimatedFare([FromBody] CompareTaxRequest request)
        {
            if (request == null || request.FirstYear <= 0 || request.SecondYear <= 0 || request.UserId <= 0)
            {
                return BadRequest("Invalid request data.");
            }

            // Fetch tax details for the specified years and user
            var detailForFirstYear = await _context.TaxInfos
                .FirstOrDefaultAsync(t => t.UserId == request.UserId && t.AssessmentYear == request.FirstYear);

            var detailForSecondYear = await _context.TaxInfos
                .FirstOrDefaultAsync(t => t.UserId == request.UserId && t.AssessmentYear == request.SecondYear);

            if (detailForFirstYear == null || detailForSecondYear == null)
            {
                return NotFound("Data not found for the given years.");
            }

            //return Ok(new
            //{
            //    DetailForFirstYear = detailForFirstYear,
            //    DetailForSecondYear = detailForSecondYear
            //});

            var response = new TaxComparisonResponse
            {
                DetailForFirstYear = detailForFirstYear,
                DetailForSecondYear = detailForSecondYear
            };

            return Ok(response);
        }


        [HttpGet("taxinfo/assessmentyear/{userId}")]
        public async Task<ActionResult<IEnumerable<int>>> GetAssessmentYearsByUserId(int userId)
        {
            var assessmentYears = await _context.TaxInfos
                .Where(t => t.UserId == userId)
                .Select(t => t.AssessmentYear)
                .ToListAsync();

            if (assessmentYears == null || !assessmentYears.Any())
            {
                return NotFound();
            }

            return Ok(assessmentYears);
        }


        [HttpGet("userdetails/{id}")]
        public async Task<ActionResult<IEnumerable<TaxInfo>>> GetDetailsForCA(int id)
        {
            if (_context.TaxInfos == null)
            {
                return NotFound();
            }
            //var taxInfo = await _context.TaxInfos.FindAsync(id);
            var taxInfo = await _context.TaxInfos
            .Where(t => t.UserId == id)
            .ToListAsync();

            if (taxInfo == null)
            {
                return NotFound();
            }

            return taxInfo;
        }


        private bool TaxInfoExists(int id)
        {
            return (_context.TaxInfos?.Any(e => e.TaxInfoId == id)).GetValueOrDefault();
        }
    }
}
