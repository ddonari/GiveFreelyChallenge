using GiveFreelyChallenge.Controllers;
using GiveFreelyChallenge.Domain.Data;
using GiveFreelyChallenge.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GiveFreelyChallenge.API.Controllers.Tests

{
    [TestClass]
    public class CommissionControllerTests
    {
        [TestMethod]
        public async Task GetCommissionCount_ReturnsCorrectCount()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(dbContextOptions);
            var controller = new CommissionController(context);
            var affiliateId = 1;
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1", AffiliateId = affiliateId },
                new Customer { Name = "Customer 2", AffiliateId = affiliateId },
                new Customer { Name = "Customer 3", AffiliateId = affiliateId + 1 }
            };
            context.Customers.AddRange(customers);
            await context.SaveChangesAsync();

            // Act
            var result = await controller.GetCommissionCount(affiliateId) as ActionResult<int>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customers.Count(c => c.AffiliateId == affiliateId), result.Value);
        }

        [TestMethod]
        public async Task GetCommissionCount_ReturnsZeroForNonExistingAffiliateId()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(dbContextOptions);
            var controller = new CommissionController(context);
            var affiliateId = 1;
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1", AffiliateId = affiliateId + 1 },
                new Customer { Name = "Customer 2", AffiliateId = affiliateId + 2 }
            };
            context.Customers.AddRange(customers);
            await context.SaveChangesAsync();

            // Act
            var result = await controller.GetCommissionCount(affiliateId) as ActionResult<int>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Value);
        }
    }
}