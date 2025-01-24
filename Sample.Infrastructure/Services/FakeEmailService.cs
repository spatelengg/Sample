using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sample.Application.Service;

namespace Sample.Infrastructure.Services
{
    public class FakeEmailService : IEmailService
    {
        private readonly ILogger<FakeEmailService> _logger;
        public FakeEmailService(ILogger<FakeEmailService> logger)
        {
            _logger = logger;
        }
        public Task SendEmailAsync(string to, string from, string subject, string body)
        {
            _logger.LogInformation($"Fake email: To: {to}\nSubject: {subject}\n{body}");
            return Task.CompletedTask;
        }
    }
}
