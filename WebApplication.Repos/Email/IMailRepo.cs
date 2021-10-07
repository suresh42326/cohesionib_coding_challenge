using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Repos.Email
{
    public interface IMailRepo
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
