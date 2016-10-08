namespace Yxc.Entities.v1
{
    public class EventData
    {
        // ReSharper disable All 
        public EventDataSystem system { get; set; }

        public EventDataMain main { get; set; }

        //object zone2; // Reserved
        //object zone3; // Reserved
        //object zone4; // Reserved

        public EventDataTuner tuner { get; set; }

        public EventDataNetusb netusb { get; set; }

        public EventDataCd cd { get; set; }

        public EventDataDist dist { get; set; }

        // object clock; // Reserved

        public string device_id{ get; set; }

        public class EventDataSystem
        {
            public bool bluetooth_info_updated { get; set; }
            public bool func_status_updated { get; set; }
            public bool speaker_settings_updated { get; set; }
            public bool name_text_updated { get; set; }
            public bool tag_updated { get; set; }
            public bool location_info_updated { get; set; }
            public bool stereo_pair_info_updated { get; set; }

        }

        public class EventDataMain
        {
            public string power { get;  set; }
            public string input { get;  set; }
            public int? volume { get;  set; }
            public bool? mute { get;  set; }
            public bool status_updated { get;  set; }
            public bool signal_info_updated { get;  set; }
        }

        public class EventDataTuner
        {
            public bool play_info_updated { get; set; }
            public bool preset_info_updated { get; set; }
        }

        public class EventDataNetusb
        {
            public int? play_error { get; set; }
            public int? multiple_play_errors { get; set; }
            public string play_message { get; set; }
            public bool account_updated { get; set; }
            public int? play_time { get; set; }
            public bool preset_info_updated { get; set; }
            public bool recent_info_updated { get; set; }

            public EventDataPresetControl preset_control { get; set; }

            public EventDataTrialStatus trial_status { get; set; }

            public EventDataTrialTimeLeft trial_time_left { get; set; }

            public bool play_info_updated { get; set; }

            public bool list_info_updated { get; set; }

            public class EventDataPresetControl
            {
                public string type { get; set; }
                public int? num { get; set; }
                public string result { get; set; }
            }

            public class EventDataTrialStatus
            {
                public string input { get; set; }
                public bool enable { get; set; }
            }

            public class EventDataTrialTimeLeft
            {
                public string input { get; set; }
                public int? time { get; set; }
            }
        }

        public class EventDataCd
        {
            public string device_status { get; set; }
            public int? play_time { get; set; }

            public bool play_info_updated { get; set; }
        }

        public class EventDataDist
        {
            public bool dist_info_updated { get; set; }
        }

        // ReSharper restore All
    }
}
