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
using WebApplication.Models;
using WebApplication.Repos;
using WebApplication.Repos.EFCore;
using WebApplication.Repos.Email;
using WebApplication1.Controllers;
using WebApplication1.Models;
using Xunit;

namespace WebApplication1.Tests
{
    public class ServiceRequestTest : IClassFixture<ServiceRequestSeedDataFixture>
    {
        ServiceRequestSeedDataFixture fixture;
        public ServiceRequestTest(ServiceRequestSeedDataFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task GetAllTestAsync()
        {
            EFCoreServiceRequestRepo requestRepo = new EFCoreServiceRequestRepo(this.fixture.WebApplication1Context);
            List<ServiceRequest> requests = await requestRepo.GetAll();
            Assert.Equal(3, requests.Count);

        }

        [Fact]
        public async Task GetByIdTestAsync()
        {
            EFCoreServiceRequestRepo requestRepo = new EFCoreServiceRequestRepo(this.fixture.WebApplication1Context);
            ServiceRequest request = await requestRepo.Get("1");
            Assert.Equal("1", request.Id);

        }

        [Fact]
        public async Task UpdateTestAsync()
        {

            EFCoreServiceRequestRepo requestRepo = new EFCoreServiceRequestRepo(this.fixture.WebApplication1Context);
            ServiceRequest request = await requestRepo.Get("1");
            request.CurrentStatus = CurrentStatus.Canceled;
            await requestRepo.Update(request);
            Assert.Equal(CurrentStatus.Canceled, request.CurrentStatus);

        }


    }


}
