namespace Yxc.Entities.v1.system
{
    // ReSharper disable All 
    public class GetDeviceInfo
    {
        public int response_code { get; set; }
        public string model_name { get; set; }
        public string destination { get; set; }
        public string system_id { get; set; }
        public double system_version { get; set; }
        public double api_version { get; set; }
        public string netmodule_version { get; set; }
        public string netmodule_checksum { get; set; }
        public string operation_mode { get; set; }
        public string update_error_code { get; set; }
        // update_progress object Reserved 
    }
    // ReSharper restore All
}
