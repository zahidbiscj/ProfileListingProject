﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Entities
{
    public class MailMessage
    {
        public string Sender { get; set; }
        public string SenderName { get; set; }
        public string Receiver { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
