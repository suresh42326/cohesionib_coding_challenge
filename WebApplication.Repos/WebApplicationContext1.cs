using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.Repos
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context(DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.ServiceRequest> ServiceRequest { get; set; }
    }
}
