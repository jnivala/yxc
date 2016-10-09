using System.Collections.Generic;

namespace Yxc.Entities.v1.Netusb
{
    // ReSharper disable All
    public class GetAccountStatus
    {
        public int response_code { get; set; }
        public List<ServiceList> service_list { get; set; }

        public class ServiceList
        {
            public string id { get; set; }
            public bool registered { get; set; }
            public string login_status { get; set; }
            public string username { get; set; }
            public string type { get; set; }
            public int trial_time_left { get; set; }
        }
    }
    // ReSharper restore All
}
