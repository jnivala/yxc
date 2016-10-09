namespace Yxc.Entities.v1.System
{
    // ReSharper disable All 
    public class GetLocationInfoResponse
    {
        public int response_code { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public ZoneList zone_list { get; set; }
        /// <summary>
        /// Reserved (type specified, however).
        /// </summary>
        public string stereo_pair_status { get; set; }

        public class ZoneList
        {
            public bool main { get; set; }
            public bool zone2 { get; set; }
            public bool zone3 { get; set; }
            public bool zone4 { get; set; }
        }
    }
    // ReSharper restore All
}
