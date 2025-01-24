using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Service
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
