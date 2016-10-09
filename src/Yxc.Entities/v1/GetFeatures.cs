using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yxc.Entities.v1
{
    // ReSharper disable All 
    public class GetFeatures
    {
        public int response_code { get; set; }
        public System system { get; set; }
        public List<Zone> zone { get; set; }
        public Tuner tuner { get; set; }
        public Netusb netusb { get; set; }

        public class InputList
        {
            public string id { get; set; }
            public bool distribution_enable { get; set; }
            public bool rename_enable { get; set; }
            public bool account_enable { get; set; }
            public string play_info_type { get; set; }
        }

        public class System
        {
            public List<string> func_list { get; set; }
            public int zone_num { get; set; }
            public List<InputList> input_list { get; set; }
            public List<string> ymap_list { get; set; }
        }

        public class RangeStep
        {
            public string id { get; set; }
            public int min { get; set; }
            public int max { get; set; }
            public int step { get; set; }
        }

        public class Zone
        {
            public string id { get; set; }
            public List<string> func_list { get; set; }
            public List<string> input_list { get; set; }
            public List<string> link_control_list { get; set; }
            public List<RangeStep> range_step { get; set; }
        }

        public class Preset
        {
            public string type { get; set; }
            public int num { get; set; }
        }

        public class Tuner
        {
            public List<string> func_list { get; set; }
            public List<RangeStep> range_step { get; set; }
            public Preset preset { get; set; }
        }

        public class Preset2
        {
            public int num { get; set; }
        }

        public class RecentInfo
        {
            public int num { get; set; }
        }

        public class Netusb
        {
            public List<string> func_list { get; set; }
            public Preset2 preset { get; set; }
            public RecentInfo recent_info { get; set; }
        }
    }

    // ReSharper restore All
}
