namespace Yxc.Entities.v1.system
{
    // ReSharper disable All 
    public class GetNetworkStatus
    {
        public int response_code { get; set; }
        public string network_name { get; set; }
        public string connection { get; set; }
        public bool dhcp { get; set; }
        public string ip_address { get; set; }
        public string subnet_mask { get; set; }
        public string default_gateway { get; set; }
        public string dns_server_1 { get; set; }
        public string dns_server_2 { get; set; }
        public WirelessLan wireless_lan { get; set; }
        public WirelessDirect wireless_direct { get; set; }
        public MusiccastNetwork musiccast_network { get; set; }
        public MacAddress mac_address { get; set; }
        public string vtuner_id { get; set; }
        public string airplay_pin { get; set; }

        public class WirelessLan
        {
            public string ssid { get; set; }
            public string type { get; set; }
            public string key { get; set; }
            public int ch { get; set; }
            public int strength { get; set; }
        }

        public class WirelessDirect
        {
            public string ssid { get; set; }
            public string type { get; set; }
            public string key { get; set; }
        }

        public class MusiccastNetwork
        {
            public bool ready { get; set; }
            public string device_type { get; set; }
            public int child_num { get; set; }
            public int ch { get; set; }
            public bool initial_join_running { get; set; }
        }

        public class MacAddress
        {
            public string wired_lan { get; set; }
            public string wireless_lan { get; set; }
            public string wireless_direct { get; set; }
        }
    }
    // ReSharper restore All 
}
