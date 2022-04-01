using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Infrastructure.Services.SendEmail
{
    public interface ISendEmail
    {
        Task Send(string to, string subject, string html);
    }
}
