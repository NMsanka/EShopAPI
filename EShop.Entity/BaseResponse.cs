using System.ComponentModel;

namespace EShop.Entity
{
    public class BaseResponse
    {
        [Description("ClientToken")]
        public string ClientToken { get; set; }

        [Description("SessionToken")]
        public string SessionToken { get; set; }

        [Description("IsError")]
        public bool IsError { get; set; }

        [Description("Message")]
        public string Message { get; set; }

        [Description("DeveloperLog")]
        public string DeveloperLog { get; set; }

        [Description("IsNull")]
        public bool IsNull { get; set; }
    }
}
