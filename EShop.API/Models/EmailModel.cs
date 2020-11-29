using System.Collections.Generic;

namespace EShop.API.Models
{
    public class EmailModel
    {
        /// <summary>
        /// Gets or sets the recipient addresses.
        /// </summary>
        /// <value>
        /// The recipient addresses.
        /// </value>
        public IList<string> RecipientAddresses { get; set; }

        /// <summary>
        /// Gets or sets the cc addresses.
        /// </summary>
        /// <value>
        /// The cc addresses.
        /// </value>
        public IList<string> CCAddresses { get; set; }

        /// <summary>
        /// Gets or sets the BCC.
        /// </summary>
        /// <value>
        /// The BCC.
        /// </value>
        /// </value>
        public string Bcc { get; set; }

        /// <summary>
        /// Gets or sets the FromMail.
        /// </summary>
        /// <value>
        /// The FromMail.
        /// </value>
        public string FromMail { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the name of the sender.
        /// </summary>
        /// <value>
        /// The name of the sender.
        /// </value>
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>
        /// The signature.
        /// </value>
        public string Signature { get; set; }

        /// <summary>
        /// Gets or sets the attachment path.
        /// </summary>
        /// <value>
        /// The attachment path.
        /// </value>
        public IList<AttachmentModel> Attachments { get; set; }

        /// <summary>
        /// Gets or sets the content of the attachment.
        /// </summary>
        /// <value>
        /// The content of the attachment.
        /// </value>
        public object AttachmentContent { get; set; }

    }
}