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
    public class UserDatumsController : ControllerBase
    {
        private readonly UserTaxInfoContext _context = new UserTaxInfoContext();

        //public UserDatumsController(UserTaxInfoContext context)
        //{
        //    _context = context;
        //}

        // GET: api/UserDatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDatum>>> GetUserData()
        {
          if (_context.UserData == null)
          {
              return NotFound();
          }
            return await _context.UserData.ToListAsync();
        }

        // GET: api/UserDatums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDatum>> GetUserDatum(int id)
        {
          if (_context.UserData == null)
          {
              return NotFound();
          }
            var userDatum = await _context.UserData.FindAsync(id);

            if (userDatum == null)
            {
                return NotFound();
            }

            return userDatum;
        }

        // PUT: api/UserDatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDatum(int id, UserDatum userDatum)
        {
            if (id != userDatum.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDatumExists(id))
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

        // POST: api/UserDatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDatum>> PostUserDatum(UserDatum userDatum)
        {
          if (_context.UserData == null)
          {
              return Problem("Entity set 'UserTaxInfoContext.UserData'  is null.");
          }
            _context.UserData.Add(userDatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDatum", new { id = userDatum.UserId }, userDatum);
        }

        // DELETE: api/UserDatums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDatum(int id)
        {
            if (_context.UserData == null)
            {
                return NotFound();
            }
            var userDatum = await _context.UserData.FindAsync(id);
            if (userDatum == null)
            {
                return NotFound();
            }

            _context.UserData.Remove(userDatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost("Register")]
        public async Task<ActionResult<UserDatum>> RegisterUserDatum(UserDatum userDatum)
        {
            if (_context.UserData == null)
            {
                return Problem("Entity set 'UserTaxInfoContext.UserData'  is null.");
            }
            _context.UserData.Add(userDatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDatum", new { id = userDatum.UserId }, userDatum);
        }


        // POST: api/Users/Login
        //[HttpPost("Login")]
        //public async Task<ActionResult<bool>> Login([FromBody] LoginRequest loginRequest)
        //{
        //    if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.email) || string.IsNullOrWhiteSpace(loginRequest.password))
        //    {
        //        return BadRequest("Invalid login request.");
        //    }

        //    if (_context == null || _context.UserData == null)
        //    {
        //        return NotFound("User not found.");
        //    }

        //    // Find the user by UserName
        //    //var user = await _context.Users.FindAsync(loginRequest.UserName);
        //    var user = await _context.UserData.FirstOrDefaultAsync(u => u.UserName == loginRequest.email);

        //    if (user == null)
        //    {
        //        return NotFound("User not found.");
        //    }

        //    // Check if the password matches
        //    bool isPasswordValid = loginRequest.password == UserDatum.UserPassword;



        //    if (!isPasswordValid)
        //    {
        //        return Unauthorized("Invalid credentials.");
        //    }

        //    return Ok(true); // Login successful
        //}


        private bool UserDatumExists(int id)
        {
            return (_context.UserData?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
