using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.API.Models
{
    public class SMSModel
    {
        /// Gets or sets the recipient mobile number.
        public string RecipientNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PreferredName { get; set; }

        /// Gets or sets the message.
        public string Message { get; set; }

        /// Gets or sets the sender.
        public string Sender { get; set; }

        public string Device { get; set; }

        public bool isShortCode { get; set; }
    }
}