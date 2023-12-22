using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiveFreelyChallenge.Controllers;
using GiveFreelyChallenge.Domain.Data;
using GiveFreelyChallenge.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GiveFreelyChallenge.API.Controllers.Tests
{
    [TestClass]
    public class CustomersControllerTests
    {
        [TestMethod]
        public async Task CreateCustomer_ReturnsCreatedAtAction()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(dbContextOptions);
            var controller = new CustomersController(context);
            var customer = new Customer { Name = "Customer 1" };

            // Act
            var result = await controller.CreateCustomer(customer) as CreatedAtActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(nameof(controller.GetCustomer), result.ActionName);
        }

        [TestMethod]
        public async Task GetCustomers_ReturnsListOfCustomers()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(dbContextOptions);
            var controller = new CustomersController(context);

            // Act
            var result = await controller.GetCustomers() as ActionResult<IEnumerable<Customer>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Value, typeof(List<Customer>));
        }

        [TestMethod]
        public async Task GetCustomer_ReturnsCustomerById()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(dbContextOptions);
            var controller = new CustomersController(context);
            var customer = new Customer {Name = "Customer 1" };
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            // Act
            var result = await controller.GetCustomer(customer.Id) as ActionResult<Customer>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customer.Id, result.Value.Id);
        }

        [TestMethod]
        public async Task GetCustomersByAffiliate_ReturnsCustomersWithAffiliateId()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(dbContextOptions);
            var controller = new CustomersController(context);
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
            var result = await controller.GetCustomersByAffiliate(affiliateId) as ActionResult<IEnumerable<Customer>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customers.Count(c => c.AffiliateId == affiliateId), result.Value.Count());
        }
    }
}
