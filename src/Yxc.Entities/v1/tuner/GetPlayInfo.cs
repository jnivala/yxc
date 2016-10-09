namespace Yxc.Entities.v1.Tuner
{
    // ReSharper disable All
    public class GetPlayInfo
    {
        public int response_code { get; set; }
        public string band { get; set; }
        public bool auto_scan { get; set; }
        public Am am { get; set; }
        public Fm fm { get; set; }
        public Rds rds { get; set; }
        public Dab dab { get; set; }

        public class Am
        {
            public int preset { get; set; }
            public int freq { get; set; }
            public bool tuned { get; set; }
            /// <summary>
            /// R-N602 v1.12 does not set.
            /// </summary>
            public string audio_mode { get; set; }
        }

        public class Fm
        {
            public int preset { get; set; }
            public int freq { get; set; }
            public bool tuned { get; set; }
        }

        public class Rds
        {
            public string program_type { get; set; }
            public string program_service { get; set; }
            public string radio_text_a { get; set; }
            public string radio_text_b { get; set; }
        }

        public class Dab
        {
            public int preset { get; set; }
            public int id { get; set; }
            public string status { get; set; }
            public int freq { get; set; }
            public string category { get; set; }
            public string audio_mode { get; set; }
            public int bit_rate { get; set; }
            public int quality { get; set; }
            public int tune_aid { get; set; }
            public bool off_air { get; set; }
            public bool dab_plus { get; set; }
            public string program_type { get; set; }
            public string ch_label { get; set; }
            public string service_label { get; set; }
            public string dls { get; set; }
            public string ensemble_label { get; set; }
            public int initial_scan_progress { get; set; }
            public int total_station_num { get; set; }
            // hd_radio object Reserved
        }
    }
    // ReSharper restore All
}
