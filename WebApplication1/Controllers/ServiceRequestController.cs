using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;
using WebApplication.Repos.EFCore;
using WebApplication.Repos.Email;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : BaseController<ServiceRequest, EFCoreServiceRequestRepo>
    {
        private EFCoreServiceRequestRepo _repo;
        private IMailRepo _mailRepo;
        public ServiceRequestController(EFCoreServiceRequestRepo repository, IMailRepo mailRepo) : base(repository)
        {
            _repo = repository;
            _mailRepo = mailRepo;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public override async Task<IActionResult> Put(string id, ServiceRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            await _repo.Update(request);
            if (request.CurrentStatus == WebApplication.Models.CurrentStatus.Complete)
            {
                MailRequest mailRequest = new MailRequest()
                {
                    Body = "Request closed",
                    Subject = "Request closed",
                    ToEmail = "suresh42326@gmail.com"
                };
                await _mailRepo.SendEmailAsync(mailRequest);
            }
            return NoContent();
        }


    }
}
