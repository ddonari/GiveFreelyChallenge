using GiveFreelyChallenge.Domain.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiveFreelyChallenge.Domain.Models;

namespace GiveFreelyChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffiliatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AffiliatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAffiliate(Affiliate affiliate)
        {
            _context.Affiliates.Add(affiliate);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAffiliate), new { id = affiliate.Id }, affiliate);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Affiliate>>> GetAffiliates()
        {
            return await _context.Affiliates.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Affiliate>> GetAffiliate(int id)
        {
            var affiliate = await _context.Affiliates.FindAsync(id);

            if (affiliate == null)
            {
                return NotFound();
            }

            return affiliate;
        }
    }
}
