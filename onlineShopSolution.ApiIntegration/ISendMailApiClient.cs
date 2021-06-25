using onlineShopSolution.ViewModel.SendMail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.ApiIntegration
{
    public interface ISendMailApiClient
    {
        Task SendMail(MailContent mailContent);

        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
