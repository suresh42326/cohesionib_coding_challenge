using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Repos;
using WebApplication.Repos.EFCore;
using WebApplication.Repos.Email;
using WebApplication1.Controllers;
using WebApplication1.Models;
using Xunit;

namespace WebApplication1.Tests
{
    public class ServiceRequestTest
    {
        [Fact]
        public async Task GetAllTestAsync()
        {
            var options = new DbContextOptionsBuilder<WebApplication1Context>()
                .UseInMemoryDatabase(databaseName: "ServiceRequestMockDB")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new WebApplication1Context(options))
            {
                context.ServiceRequest.Add(new ServiceRequest { Id = "1" });
                context.ServiceRequest.Add(new ServiceRequest { Id = "2" });
                context.ServiceRequest.Add(new ServiceRequest { Id = "3" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new WebApplication1Context(options))
            {
                EFCoreServiceRequestRepo requestRepo = new EFCoreServiceRequestRepo(context);
                List<ServiceRequest> requests = await requestRepo.GetAll();

                Assert.Equal(3, requests.Count);
            }
        }

    }


}
