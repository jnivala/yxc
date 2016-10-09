namespace Yxc.Entities.v1.System
{
    // ReSharper disable All 
    public class GetFuncStatusResponse
    {
        public int response_code { get; set; }
        public bool auto_power_standby { get; set; }
        public bool speaker_a { get; set; }
        public bool speaker_b { get; set; }
        public bool headphone { get; set; }
    }
    // ReSharper restore All
}