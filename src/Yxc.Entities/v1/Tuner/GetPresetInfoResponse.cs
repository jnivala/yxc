using System.Collections.Generic;

namespace Yxc.Entities.v1.Tuner
{
    // ReSharper disable All
    public class GetPresetInfoResponse
    {
        public int response_code { get; set; }
        public List<PresetInfo> preset_info { get; set; }
        public List<string> func_list { get; set; }

        public class PresetInfo
        {
            public string band { get; set; }
            public int number { get; set; }
            public int hd_program { get; set; }
        }
    }
    // ReSharper restore All
}
