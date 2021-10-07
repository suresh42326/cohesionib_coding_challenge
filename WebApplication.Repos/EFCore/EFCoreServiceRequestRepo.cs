using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Repos.Email;
using WebApplication1.Models;

namespace WebApplication.Repos.EFCore
{
    public class EFCoreServiceRequestRepo : EfCoreRepository<ServiceRequest, WebApplication1Context>
    {
        private WebApplication1Context _context;
        public EFCoreServiceRequestRepo(WebApplication1Context context) : base(context)
        {
            _context = context;
        }

       
    }
}
