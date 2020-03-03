using Autofac;
using Microsoft.Extensions.Configuration;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Models
{
    public class MailSendingModel : BaseModel
    {
        public string Body { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public string SenderName { get; set; }
        public string Subject { get; set; }
        
        private readonly IConfiguration _config;
        public MailSendingModel()
        {
            _config = Startup.AutoFacContainer.Resolve<IConfiguration>();    
        }
        public MailSendingModel(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void SendingMail()
        {
            try
            {
                using (var mailSender = new MailSender(_config))
                {
                    mailSender.Send(new List<MailMessage>
                    {
                           new MailMessage
                           {
                               Body = this.Body,
                               Receiver = "hashtag626768@gmail.com",
                               Sender = this.Sender,
                               SenderName = this.SenderName,
                               Subject = this.Subject
                           }
                    });
                }
                Notification = new NotificationModel("Mail Sent Successfully !!", "We will Review your account and contact you Via Email. Stay with us. Thank You.", NotificationType.Success);
            }
            catch (Exception)
            {
                Notification = new NotificationModel("Failed to Sent Mail", "Please Review your Account Information Correctly or Try back Later", NotificationType.Fail);
                throw;
            }
            
        }
    }
}
