using System.Collections.Generic;

namespace Yxc.Entities.v1.Netusb
{
    // Resharper disable All
    public class GetPresetInfo
    {
        public int response_code { get; set; }
        public List<PresetInfo> preset_info { get; set; }
        public List<string> func_list { get; set; }

        public class PresetInfo
        {
            public string input { get; set; }
            public string text { get; set; }
        }
    }
    // Resharper restore All
}
