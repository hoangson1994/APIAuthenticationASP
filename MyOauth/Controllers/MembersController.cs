using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOauth.Models;

namespace MyOauth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MembersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Members
        [HttpGet]
        public IEnumerable<Member> GetMembers()
        {
            
            return _context.Members;
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var member = await _context.Members.FindAsync(id);
            
            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/Members/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember([FromRoute] long id, [FromBody] Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != member.ID)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/Members
        [HttpPost]
        public async Task<IActionResult> PostMember([FromBody] Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(_context.Members.FirstOrDefault(m => m.Email == member.Email) != null)
            {
                return BadRequest(new { status = 400, message = "Email existed" });
            }
            member.Salt = Utility.Utility.RandomString(5);
            member.Password = Utility.Utility.MD5Hash(member.Password + member.Salt);
                       
            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMember", new { id = member.ID }, member);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return Ok(member);
        }
        
        private bool MemberExists(long id)
        {          
            return _context.Members.Any(e => e.ID == id);
        }
      
    }
}