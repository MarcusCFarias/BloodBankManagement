using BloodBankManagement.Application.Features.BloodStorage;
using BloodBankManagement.Domain.Events;
using BloodBankManagement.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace BloodBankManagement.Application.Features.Events
{
    public class BloodStockBelowTheMinimunEventHandler : INotificationHandler<BloodStockBelowTheMinimunEvent>
    {
        private readonly IBloodStorageRepository _bloodStorageRepository;
        private readonly ILogger _logger;
        public BloodStockBelowTheMinimunEventHandler(IBloodStorageRepository bloodStorageRepository,
            ILogger<BloodStockBelowTheMinimunEvent> logger)
        {
            _logger = logger;
            _bloodStorageRepository = bloodStorageRepository;
        }

        public async Task Handle(BloodStockBelowTheMinimunEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"BloodStockBelowTheMinimunEvent: {notification.BloodStockId}");
            await SendWarningEmailAsync(notification.BloodStockId);
        }
        private async Task SendWarningEmailAsync(int bloodStockId)
        {
            string smtpServer = "smtp.gmail.com";
            int smptPort = 465;
            string mail = "yourEmail";
            string password = "appPassword";

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Your Name", mail));
            email.To.Add(new MailboxAddress("", mail));
            email.Subject = "Blood Stock Below The Minimum";
            email.Body = new TextPart("plain")
            {
                Text = "The blood stock is below the minimum level."
            };


            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpServer, smptPort, true);
                await client.AuthenticateAsync(mail, password);
                await client.SendAsync(email);
                await client.DisconnectAsync(true);
            }
        }
    }
}
