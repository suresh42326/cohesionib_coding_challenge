using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Repos.EFCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : BaseController<ServiceRequest, EFCoreServiceRequestRepo>
    {
        public ServiceRequestController(EFCoreServiceRequestRepo repository) : base(repository)
        {

        }


    }
}
