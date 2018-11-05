using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOauth.Models;
using Newtonsoft.Json.Linq;

namespace MyOauth.Controllers
{
    [Route("api/members/authentication")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CredentialsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication([FromBody] Account account) {
            if(account.Email == null || account.Password == null)
            {
                return BadRequest(new { status = 400, message = "Email or Password not null" });
            }
            Member member =  _context.Members.FirstOrDefault(m => m.Email == account.Email);
            if(member == null)
            {
                return NotFound();
            }
            if(Utility.Utility.MD5Hash(account.Password + member.Salt) != member.Password)
            {
                return BadRequest(new { status = 400, message = "Password incorrect"});
            }

            Credential credential = Credential.GenerateCridential(member.ID, CredentialScope.Basic);        
          
            _context.Credentials.Add(credential);
            await _context.SaveChangesAsync();
           
            return Ok(credential);
                          
        }                      
    }
}