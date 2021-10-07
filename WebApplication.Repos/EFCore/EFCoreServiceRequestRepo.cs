using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.Models;

namespace WebApplication.Repos.EFCore
{
    public class EFCoreServiceRequestRepo : EfCoreRepository<ServiceRequest, WebApplication1Context>
    {
        public EFCoreServiceRequestRepo(WebApplication1Context context) : base(context)
        {

        }
    }
}
