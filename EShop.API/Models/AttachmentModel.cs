using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.API.Models
{
    public class AttachmentModel
    {
        /// Gets or sets the attachment path.
        public string Path { get; set; }

        /// Gets or sets the attachment type.
        public AttacmentTypes Type { get; set; }

        /// Gets or sets the attachment name.
        public string Name { get; set; }
    }
}