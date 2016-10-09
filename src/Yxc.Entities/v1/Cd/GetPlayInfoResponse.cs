namespace Yxc.Entities.v1.Cd
{
    // ReSharper disable All
    public class GetPlayInfoResponse
    {
        public int response_code { get; set; }
        public string device_status { get; set; }
        public string playback { get; set; }
        public string repeat { get; set; }
        public string shuffle { get; set; }
        public int play_time { get; set; }
        public int total_time { get; set; }
        public int disc_time { get; set; }
        public int track_number { get; set; }
        public int total_tracks { get; set; }
        public string artist { get; set; }
        public string album { get; set; }
        public string track { get; set; }
    }
    // ReSharper restore All
}
