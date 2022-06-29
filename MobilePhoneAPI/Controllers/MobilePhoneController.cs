using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobilePhoneAPI.Data;

namespace MobilePhoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobilePhoneController : ControllerBase
    {
        private readonly DataContext _context;
        public MobilePhoneController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MobilePhone>>> GetMobilePhone()
        {
            return Ok(await _context.MobilePhones.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<MobilePhone>>> CreateMobilePhone(MobilePhone phone)
        {
            _context.MobilePhones.Add(phone);
            await _context.SaveChangesAsync();

            return Ok(await _context.MobilePhones.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<MobilePhone>>> UpdateMobilePhone(MobilePhone phone)
        {
            var dbPhone = await _context.MobilePhones.FindAsync(phone.Id);
            if (dbPhone == null)
                return BadRequest("Phone not found.");

            dbPhone.Firm = phone.Firm;
            dbPhone.Model = phone.Model;
            dbPhone.Price = phone.Price;


            await _context.SaveChangesAsync();

            return Ok(await _context.MobilePhones.ToListAsync());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<MobilePhone>>> DeleteMobilePhone(int id)
        {
            var dbPhone = await _context.MobilePhones.FindAsync(id);
            if (dbPhone == null)
                return BadRequest("Phone not found");

            _context.MobilePhones.Remove(dbPhone);
            await _context.SaveChangesAsync();

            return Ok(await _context.MobilePhones.ToListAsync());
        }
        
    }
}
