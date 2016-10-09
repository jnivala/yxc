using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yxc.Entities.v1
{
    // ReSharper disable All
    public class GetPresetInfo
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
