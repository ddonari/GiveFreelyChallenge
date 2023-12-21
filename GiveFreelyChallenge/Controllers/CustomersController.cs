using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiveFreelyChallenge.Domain.Data;
using GiveFreelyChallenge.Domain.Models;

namespace GiveFreelyChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpGet("byAffiliate/{affiliateId}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByAffiliate(int affiliateId)
        {
            return await _context.Customers.Where(c => c.AffiliateId == affiliateId).ToListAsync();
        }
    }

}
