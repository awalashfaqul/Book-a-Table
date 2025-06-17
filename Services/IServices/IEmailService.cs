using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Services.IServices
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string email, string subject, string htmlContent);
    }
}