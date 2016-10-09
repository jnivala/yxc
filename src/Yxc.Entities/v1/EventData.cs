namespace Yxc.Entities.v1
{
    // ReSharper disable All 
    public class EventData
    {
        public System system { get; set; }
        public Main main { get; set; }
        //object zone2; // Reserved
        //object zone3; // Reserved
        //object zone4; // Reserved
        public Tuner tuner { get; set; }
        public Netusb netusb { get; set; }
        public Cd cd { get; set; }
        public Dist dist { get; set; }
        // object clock; // Reserved

        public string device_id { get; set; }

        public class System
        {
            public bool bluetooth_info_updated { get; set; }
            public bool func_status_updated { get; set; }
            public bool speaker_settings_updated { get; set; }
            public bool name_text_updated { get; set; }
            public bool tag_updated { get; set; }
            public bool location_info_updated { get; set; }
            public bool stereo_pair_info_updated { get; set; }
        }

        public class Main
        {
            public string power { get;  set; }
            public string input { get;  set; }
            public int? volume { get;  set; }
            public bool? mute { get;  set; }
            public bool status_updated { get;  set; }
            public bool signal_info_updated { get;  set; }
        }

        public class Tuner
        {
            public bool play_info_updated { get; set; }
            public bool preset_info_updated { get; set; }
        }

        public class Netusb
        {
            public int? play_error { get; set; }
            public int? multiple_play_errors { get; set; }
            public string play_message { get; set; }
            public bool account_updated { get; set; }
            public int? play_time { get; set; }
            public bool preset_info_updated { get; set; }
            public bool recent_info_updated { get; set; }
            public PresetControl preset_control { get; set; }
            public TrialStatus trial_status { get; set; }
            public TrialTimeLeft trial_time_left { get; set; }
            public bool play_info_updated { get; set; }
            public bool list_info_updated { get; set; }
        }

        public class PresetControl
        {
            public string type { get; set; }
            public int? num { get; set; }
            public string result { get; set; }
        }

        public class TrialStatus
        {
            public string input { get; set; }
            public bool enable { get; set; }
        }

        public class TrialTimeLeft
        {
            public string input { get; set; }
            public int? time { get; set; }
        }

        public class Cd
        {
            public string device_status { get; set; }
            public int? play_time { get; set; }

            public bool play_info_updated { get; set; }
        }

        public class Dist
        {
            public bool dist_info_updated { get; set; }
        }

        // ReSharper restore All
    }
}
