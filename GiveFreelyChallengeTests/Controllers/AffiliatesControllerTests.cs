using GiveFreelyChallenge.Controllers;
using GiveFreelyChallenge.Domain.Data;
using GiveFreelyChallenge.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GiveFreelyChallenge.API.Controllers.Tests

{
    [TestClass]
    public class AffiliatesControllerTests
    {
        [TestMethod]
        public async Task CreateAffiliate_ReturnsCreatedAtAction()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(dbContextOptions);
            var controller = new AffiliatesController(context);
            var affiliate = new Affiliate { Name = "Affiliate 1" };

            // Act
            var result = await controller.CreateAffiliate(affiliate) as CreatedAtActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(nameof(controller.GetAffiliate), result.ActionName);
        }

        [TestMethod]
        public async Task GetAffiliates_ReturnsListOfAffiliates()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(dbContextOptions);
            var controller = new AffiliatesController(context);

            // Act
            var result = await controller.GetAffiliates() as ActionResult<IEnumerable<Affiliate>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Value, typeof(List<Affiliate>));
        }

        [TestMethod]
        public async Task GetAffiliate_ReturnsAffiliateById()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(dbContextOptions);
            var controller = new AffiliatesController(context);
            var affiliate = new Affiliate { Name = "Affiliate 1" };
            context.Affiliates.Add(affiliate);
            await context.SaveChangesAsync();

            // Act
            var result = await controller.GetAffiliate(affiliate.Id) as ActionResult<Affiliate>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(affiliate.Id, result.Value.Id);
        }
    }
}
