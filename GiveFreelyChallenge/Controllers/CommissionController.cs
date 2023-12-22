using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiveFreelyChallenge.Domain.Data;

namespace GiveFreelyChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommissionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommissionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{affiliateId}")]
        public async Task<ActionResult<int>> GetCommissionCount(int affiliateId)
        {
            var commissionCount = await _context.Customers.CountAsync(c => c.AffiliateId == affiliateId);
            return commissionCount;
        }
    }
}
