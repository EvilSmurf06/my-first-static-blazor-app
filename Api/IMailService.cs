using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public interface IMailService
    {
        Task SendEmailAsync(string Title, string Body);
    }
}
