using System;
using System.Configuration;

namespace EShop.Configuration
{
    public static class ApplicationConfiguration
    {
        private static string GetConfigurationValueByKey(string key)
        {
            if (key == null)
                throw new ArgumentNullException("Specified configuration key is not valid.");

            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (ConfigurationErrorsException)
            {
                throw new ConfigurationErrorsException("Specified entry is not exits");
            }
        }

        private static string GetConnectionStringValueByKey(string key)
        {
            if (key == null)
                throw new ArgumentNullException("Specified configuration key is not valied.");

            try
            {
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            catch (ConfigurationErrorsException)
            {
                throw new ConfigurationErrorsException("Specified entry is not exsit");
            }
        }


        private static string GetProviderByKey(string key)
        {
            if (key == null)
                throw new ArgumentNullException("Specified configuration key is not valid.");

            try
            {
                return ConfigurationManager.ConnectionStrings[key].ProviderName;
            }
            catch (ConfigurationErrorsException)
            {
                throw new ConfigurationErrorsException("Specified entry is not exist");
            }
        }
        

        public static string ConnectionString
        {
            get
            {
                return GetConnectionStringValueByKey("EShop");
            }
        }

        public static string Provider { get { return GetProviderByKey("EShop"); } }

        public static string RepositoryPath
        {
            get
            {
                return GetConfigurationValueByKey("RepositoryPath");
            }
        }

        public static string RepositoryUrl
        {

            get
            {
                return GetConfigurationValueByKey("RepositoryUrl");
            }
        }
        public static string ApplicationUrl
        {
            get
            {
                return GetConfigurationValueByKey("ApplicationUrl");
            }
        }




        public static string PdfServerUrl
        {
            get
            {
                return GetConfigurationValueByKey("PdfServerUrl");
            }
        }

        public static string DocumentRepository
        {
            get
            {
                return GetConfigurationValueByKey("DocumentRepository");
            }
        }

        public static string DocumentRepositoryPath
        {
            get
            {
                return GetConfigurationValueByKey("DocumentRepositoryPath");
            }
        }


        public static string PhotoGalleryPath
        {
            get
            {
                return GetConfigurationValueByKey("PhotoGalleryPath");
            }
        }

        public static string CPSystemMail
        {
            get
            {
                return GetConfigurationValueByKey("CPSystemMail");
            }
        }

        public static string CPMailDisplayName
        {
            get
            {
                return GetConfigurationValueByKey("CPMailDisplayName");
            }
        }

        public static string SmtpServer
        {
            get
            {
                return GetConfigurationValueByKey("SmtpServer");
            }
        }

        public static int SmtpServerPort
        {
            get
            {
                return Convert.ToInt32(GetConfigurationValueByKey("SmtpServerPort"));
            }
        }

        public static bool IsEnableSSL
        {
            get
            {
                return Convert.ToBoolean(GetConfigurationValueByKey("IsEnableSSL"));
            }
        }

        public static string MailServerUserName
        {
            get
            {
                return GetConfigurationValueByKey("MailServerUserName");
            }
        }

        public static string MailServerPassword
        {
            get
            {
                return GetConfigurationValueByKey("MailServerPassword");
            }
        }

        public static string SGImageRoot
        {
            get
            {
                return GetConfigurationValueByKey("SG-ImageRoot");
            }
        }

        public static string MYImageRoot
        {
            get
            {
                return GetConfigurationValueByKey("MY-ImageRoot");
            }
        }

        public static string SLImageRoot
        {
            get
            {
                return GetConfigurationValueByKey("SL-ImageRoot");
            }
        }

        public static string UnitedNationsSanctionUrl
        {
            get
            {
                return GetConfigurationValueByKey("UnitedNationsSanctionUrl");
            }
        }

        public static string ServiceUrl
        {
            get
            {
                return GetConfigurationValueByKey("ServiceUrl");
            }
        }

        public static string GreenArrowDisplayName
        {
            get
            {
                return GetConfigurationValueByKey("GreenArrowDisplayName");
            }
        }
        public static string GreenArrowServer
        {
            get
            {
                return GetConfigurationValueByKey("GreenArrowServer");
            }
        }
        public static int GreenArrowServerPort
        {
            get
            {
                return Convert.ToInt32(GetConfigurationValueByKey("GreenArrowServerPort"));
            }
        }
        public static Boolean GreenArrowEnableSSL
        {
            get
            {
                return Convert.ToBoolean(GetConfigurationValueByKey("GreenArrowEnableSSL"));
            }
        }
        public static string GreenArrowServerUserName
        {
            get
            {
                return GetConfigurationValueByKey("GreenArrowServerUserName");
            }
        }
        public static string GreenArrowServerPassword
        {
            get
            {
                return GetConfigurationValueByKey("GreenArrowServerPassword");
            }
        }

        public static string GreenArrowEmail
        {
            get
            {
                return GetConfigurationValueByKey("GreenArrowEmail");
            }
        }

        public static string SMSDevice
        {
            get
            {
                return GetConfigurationValueByKey("SMSDevice");
            }
        }

        public static string SilverstreetLongCode
        {
            get
            {
                return GetConfigurationValueByKey("SilverstreetLongCode");
            }
        }

        public static string SilverstreetShortCode
        {
            get
            {
                return GetConfigurationValueByKey("SilverstreetShortCode");
            }
        }

        public static string ResizeMob
        {
            get
            {
                return GetConfigurationValueByKey("ResizeMob");
            }
        }
        public static string ResizeTab
        {
            get
            {
                return GetConfigurationValueByKey("ResizeTab");
            }
        }
        public static string ResizeWeb
        {
            get
            {
                return GetConfigurationValueByKey("ResizeWeb");
            }
        }
        public static string ExpireDate
        {
            get
            {
                return GetConfigurationValueByKey("ExpireDate");
            }
        }

        public static string EContractFunctionId
        {
            get
            {
                return GetConfigurationValueByKey("EContract");
            }
        }

        public static string GetEflyerViewUrl
        {
            get
            {
                return GetConfigurationValueByKey("EflyerViewUrl");
            }
        }
    }
}
