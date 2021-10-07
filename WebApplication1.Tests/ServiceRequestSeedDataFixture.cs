using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Models;
using WebApplication.Repos;
using WebApplication1.Models;

namespace WebApplication1.Tests
{
    public class ServiceRequestSeedDataFixture : IDisposable
    {
      
        public WebApplication1Context WebApplication1Context { get; private set; }

        public ServiceRequestSeedDataFixture()
        {
            var options = new DbContextOptionsBuilder<WebApplication1Context>()
             .UseInMemoryDatabase(databaseName: "ServiceRequestMockDB")
             .Options;
            WebApplication1Context = new WebApplication1Context(options);
            WebApplication1Context.ServiceRequest.Add(new ServiceRequest { Id = "1", CurrentStatus = CurrentStatus.Created });
            WebApplication1Context.ServiceRequest.Add(new ServiceRequest { Id = "2", CurrentStatus = CurrentStatus.InProgress });
            WebApplication1Context.ServiceRequest.Add(new ServiceRequest { Id = "3", CurrentStatus = CurrentStatus.Canceled });
            WebApplication1Context.SaveChanges();
        }

        public void Dispose()
        {
            WebApplication1Context.Dispose();
        }
    }
}
