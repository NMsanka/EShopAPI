using EShop.API.Models;
using EShop.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;


namespace EShop.API
{
    public static class EmailHelper
    {
        public static void SendEmail(EmailModel model)
        {
            if (model.RecipientAddresses == null)
                return;

            var systemMail = ApplicationConfiguration.CPSystemMail;
            var systemDisplayName = ApplicationConfiguration.CPMailDisplayName;

            try
            {
                MailMessage mail = new MailMessage();

                var smtp = new SmtpClient
                {
                    Host = ApplicationConfiguration.SmtpServer,
                    Port = ApplicationConfiguration.SmtpServerPort,
                    EnableSsl = ApplicationConfiguration.IsEnableSSL,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Timeout = Int32.MaxValue,
                    Credentials = new NetworkCredential(ApplicationConfiguration.MailServerUserName, ApplicationConfiguration.MailServerPassword)
                };

                if (string.IsNullOrEmpty(model.FromMail))
                    mail.From = new MailAddress(systemMail, systemDisplayName);
                else
                    mail.From = new MailAddress(systemMail, model.FromMail);

                if (!string.IsNullOrEmpty(model.Bcc)) mail.Bcc.Add(model.Bcc);
                foreach (var address in model.RecipientAddresses)
                {
                    if (!string.IsNullOrEmpty(model.SenderName)) mail.To.Add(new MailAddress(address, model.SenderName));
                    else mail.To.Add(new MailAddress(address));
                }
                if (model.Attachments != null && model.Attachments.Count != 0)
                {
                    foreach (var path in model.Attachments)
                    {
                        switch (path.Type)
                        {
                            case AttacmentTypes.Pdf:
                                Attachment data = new Attachment(path.Path, MediaTypeNames.Application.Pdf);
                                data.Name = "Attachment";
                                mail.Attachments.Add(data);
                                break;
                            case AttacmentTypes.Png:
                                break;
                            case AttacmentTypes.Jpg:
                                break;
                            case AttacmentTypes.WordDoc:
                                break;
                            default:
                                Attachment doc = new Attachment(path.Path, MediaTypeNames.Application.Octet);
                                doc.Name = path.Name;
                                mail.Attachments.Add(doc);
                                break;
                        }
                    }

                }

                mail.Subject = model.Subject;
                mail.Body = model.Body;
                mail.IsBodyHtml = true;

                smtp.Send(mail);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string SendGreenArrowMail(EmailModel model)
        {
            if (model.RecipientAddresses == null)
                return "Invalid Email Address";

            var systemMail = model.FromMail ?? ApplicationConfiguration.GreenArrowServerUserName;
            var systemDisplayName = ApplicationConfiguration.GreenArrowDisplayName;

            try
            {
                MailMessage mail = new MailMessage();

                var smtp = new SmtpClient
                {
                    Host = ApplicationConfiguration.GreenArrowServer,
                    Port = ApplicationConfiguration.GreenArrowServerPort,
                    EnableSsl = ApplicationConfiguration.GreenArrowEnableSSL,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Timeout = Int32.MaxValue,
                    Credentials = new NetworkCredential(ApplicationConfiguration.GreenArrowServerUserName, ApplicationConfiguration.GreenArrowServerPassword)
                };

                if (model.Attachments != null && model.Attachments.Count != 0)
                {
                    foreach (var path in model.Attachments)
                    {
                        switch (path.Type)
                        {
                            case AttacmentTypes.Pdf:
                                Attachment data = new Attachment(path.Path, MediaTypeNames.Application.Pdf);
                                data.Name = "Attachment";
                                mail.Attachments.Add(data);
                                break;
                            case AttacmentTypes.Png:
                                break;
                            case AttacmentTypes.Jpg:
                                break;
                            case AttacmentTypes.WordDoc:
                                break;
                            default:
                                Attachment doc = new Attachment(path.Path, MediaTypeNames.Application.Octet);
                                doc.Name = path.Name;
                                mail.Attachments.Add(doc);
                                break;
                        }
                    }

                }
                mail.From = new MailAddress(systemMail, systemDisplayName);
                foreach (var address in model.RecipientAddresses)
                    mail.To.Add(new MailAddress(address));

                if(model.CCAddresses != null) { 
                foreach (var address in model.CCAddresses)
                    mail.CC.Add(new MailAddress(address));
                }

                mail.Subject = model.Subject;
                var mailBody = model.Body?.Replace("\n", "");
                model.Body?.Replace(" ", "");
                mail.Body = mailBody;
                mail.IsBodyHtml = true;
               

                smtp.Send(mail);
                return "OK";
            }
            catch (Exception ex)
            {
                // throw;
                return "Server Request Failed." + ex;
            }
        }

    }
}