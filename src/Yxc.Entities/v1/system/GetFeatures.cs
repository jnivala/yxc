using System.Collections.Generic;

namespace Yxc.Entities.v1.system
{
    // ReSharper disable All 
    public class GetFeatures
    {
        public int response_code { get; set; }
        public System system { get; set; }
        public List<Zone> zone { get; set; }
        public Tuner tuner { get; set; }
        public Netusb netusb { get; set; }
        /// <summary>
        /// R-N602 v1.12 does not set.
        /// </summary>
        public Distribution distribution { get; set; }
        // clock object Reserved 

        public class System
        {
            public List<string> func_list { get; set; }
            public int zone_num { get; set; }
            public List<InputList> input_list { get; set; }
            /// <summary>
            /// R-N602 v1.12 does not set.
            /// </summary>
            public RangeStep range_step { get; set; }
            // speaker_settings object Reserved
            public List<string> ymap_list { get; set; }
            /// <summary>
            /// Reserved
            /// </summary>
            public string web_control_url { get; set; }
    }

        public class InputList
        {
            public string id { get; set; }
            public bool distribution_enable { get; set; }
            public bool rename_enable { get; set; }
            public bool account_enable { get; set; }
            public string play_info_type { get; set; }
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
            /// <summary>
            /// R-N602 v1.12 does not set.
            /// </summary>
            public int? zone_b { get; set; }
            public List<string> func_list { get; set; }
            public List<string> input_list { get; set; }
            /// <summary>
            /// R-N602 v1.12 does not set.
            /// </summary>
            public List<string> sound_program_list { get; set; }
            /// <summary>
            /// R-N602 v1.12 does not set.
            /// </summary>
            public List<string> tone_control_mode_list { get; set; }
            /// <summary>
            /// R-N602 v1.12 does not set.
            /// </summary>
            public List<string> equalizer_mode_list { get; set; }
            public List<string> link_control_list { get; set; }
            /// <summary>
            /// R-N602 v1.12 does not set.
            /// </summary>
            public List<string> link_audio_delay_list { get; set; }
            public List<RangeStep> range_step { get; set; }
        }

        public class Tuner
        {
            public List<string> func_list { get; set; }
            public List<RangeStep> range_step { get; set; }
            public Preset preset { get; set; }

            public class Preset
            {
                public string type { get; set; }
                public int num { get; set; }
            }
        }

        public class Netusb
        {
            public List<string> func_list { get; set; }
            public Preset preset { get; set; }
            public RecentInfo recent_info { get; set; }
            /// <summary>
            /// Reserved.
            /// </summary>
            public string vtuner_fver { get; set; }

            public class Preset
            {
                public int num { get; set; }
            }
        }

        public class RecentInfo
        {
            public int num { get; set; }
        }

        public class Distribution
        {
            public List<string> server_zone_list { get; set; }
        }
    }

    // ReSharper restore All
}
