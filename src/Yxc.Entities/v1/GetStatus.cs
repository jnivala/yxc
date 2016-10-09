namespace Yxc.Entities.v1
{
    // ReSharper disable All 
    public class GetStatus
    {
        public int response_code { get; set; }
        public string power { get; set; }
        public int sleep { get; set; }
        public int volume { get; set; }
        public bool mute { get; set; }
        public int max_volume { get; set; }
        public string input { get; set; }
        public bool distribution_enable { get; set; }
        public string sound_program { get; set; }
        /// <summary>
        /// R-N602 v1.12 does not return.
        /// </summary>
        public bool? direct { get; set; }
        /// <summary>
        /// R-N602 v1.12 does not return.
        /// </summary>
        public bool? pure_direct { get; set; }
        /// <summary>
        /// R-N602 v1.12 does not return.
        /// </summary>
        public ToneControl tone_control { get; set; }
        /// <summary>
        /// R-N602 v1.12 does not return.
        /// </summary>
        public Equalizer equalizer { get; set; }
        /// <summary>
        /// R-N602 v1.12 does not return.
        /// </summary>
        public int? balance { get; set; }
        /// <summary>
        /// R-N602 v1.12 does not return.
        /// </summary>
        public int? dialogue_level { get; set; }
        /// <summary>
        /// R-N602 v1.12 does not return.
        /// </summary>
        public int? dialogue_lift { get; set; }
        /// <summary>
        /// R-N602 v1.12 does not return.
        /// </summary>
        public bool? clear_voice { get; set; }
        /// <summary>
        /// R-N602 v1.12 does not return.
        /// </summary>
        public int? subwoofer_volume { get; set; }
        /// <summary>
        /// R-N602 v1.12 does not return.
        /// </summary>
        public bool? bass_extension { get; set; }
        public string link_control { get; set; }
        /// <summary>
        /// R-N602 v1.12 does not return.
        /// </summary>
        public string link_audio_delay { get; set; }
        public int disable_flags { get; set; }

        public class ToneControl
        {
            public string mode { get; set; }
            public int bass { get; set; }
            public int treble { get; set; }
        }

        public class Equalizer
        {
            public string mode { get; set; }
            public int low { get; set; }
            public int mid { get; set; }
            public int high { get; set; }
        }
    }
    // ReSharper restore All
}
